namespace InfinityScript
{
    internal static class Function
    {
        private static int _entRef;
        private static object _returnValue;

        internal static void SetEntRef(int entRef) => _entRef = entRef;

        internal static void Call(ScriptNames.FunctionList func, params Parameter[] parameters) => CallRaw((uint)func, parameters);

        internal static object GetReturns() => _returnValue;

        private static void CallRaw(uint identifier, params Parameter[] parameters)
        {
            for (int index = parameters.Length - 1; index >= 0; --index)
            {
                parameters[index].PushValue();
            }

            GameInterface.Script_Call((int)identifier, _entRef, parameters.Length);
            SetEntRef(-1);
            _returnValue = null;

            if (GameInterface.Notify_NumArgs() == 1)
            {
                switch (GameInterface.Script_GetType(0))
                {
                    case VariableType.Entity:
                        _returnValue = Entity.GetEntity(GameInterface.Script_GetEntRef(0));
                        break;
                    case VariableType.String:
                    case VariableType.IString:
                        _returnValue = GameInterface.Script_GetString(0);
                        break;
                    case VariableType.Vector:
                        GameInterface.Script_GetVector(0, out Vector3 vector);
                        _returnValue = vector;
                        break;
                    case VariableType.Float:
                        _returnValue = GameInterface.Script_GetFloat(0);
                        break;
                    case VariableType.Integer:
                        _returnValue = GameInterface.Script_GetInt(0);
                        break;
                }
            }

            GameInterface.Script_CleanReturnStack();
        }
    }
}
