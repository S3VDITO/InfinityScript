namespace InfinityScript
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class ScriptLoader
    {
        public static void Initialize()
        {
            LoadScripts();
        }

        public static void LoadScripts()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            LoadAssembly(Assembly.GetExecutingAssembly());
            LoadAssemblies("scripts", "*.auto.dll");
        }

        public static void LoadAssemblies(string dir, string filter)
        {
            foreach (string file in Directory.GetFiles(dir, filter, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    using (FileStream fileStream = new FileStream(file, FileMode.Open))
                    {
                        byte[] numArray = new byte[fileStream.Length];
                        fileStream.Read(numArray, 0, numArray.Length);
                        LoadAssembly(Assembly.Load(numArray));
                    }
                }
                catch (Exception ex)
                {
                    Utilities.PrintToConsole($"[InfinityScript] Error while loading {file}: {ex.Message}");
                }
            }
        }

        private static void LoadAssembly(Assembly assembly)
        {
            try
            {
                foreach (Type type in assembly.GetTypes().OrderBy(type => type.Name))
                {
                    if (type.IsPublic)
                    {
                        if (!type.IsAbstract)
                        {
                            try
                            {
                                if (type.IsSubclassOf(typeof(BaseScript)))
                                {
                                    Utilities.PrintToConsole($"[InfinityScript] Loading script {type.Name} v{assembly.GetName().Version}");
                                    ScriptProcessor.AddScript((BaseScript)Activator.CreateInstance(type));
                                }
                            }
                            catch (Exception ex)
                            {
                                Utilities.PrintToConsole($"[InfinityScript] An error occurred during initialization of the script {type.Name}: {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                Utilities.PrintToConsole($"[InfinityScript] Assembly {assembly.GetName()} could not be loaded because of a loader exception: {ex.LoaderExceptions[0].Message}");
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("CitizenSHManager"))
            {
                return Assembly.GetExecutingAssembly();
            }

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName == args.Name))
            {
                return assembly;
            }

            return null;
        }
    }
}