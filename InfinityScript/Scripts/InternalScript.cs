using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript.Scripts
{
    public class InternalScript : BaseScript
    {   
        public InternalScript()
        {
            GSCFunctions.SetDvarIfUninitialized("is_jumpheight", Utilities.JumpHeight);
            GSCFunctions.SetDvarIfUninitialized("is_gravity", Utilities.Gravity);
            GSCFunctions.SetDvarIfUninitialized("is_speed", Utilities.Speed);

            GSCFunctions.SetDvarIfUninitialized("is_falldamage", "1");

            Utilities.JumpHeight = float.Parse(GSCFunctions.GetDvar("is_jumpheight"));
            Utilities.Gravity = int.Parse(GSCFunctions.GetDvar("is_gravity"));
            Utilities.Speed = int.Parse(GSCFunctions.GetDvar("is_speed"));
        }

        public override bool OnServerCommand(string command, string[] args)
        {
            if (command == "set")
            {
                AfterDelay(500, () => 
                {
                    Utilities.JumpHeight = float.Parse(GSCFunctions.GetDvar("is_jumpheight"));
                    Utilities.Gravity = int.Parse(GSCFunctions.GetDvar("is_gravity"));
                    Utilities.Speed = int.Parse(GSCFunctions.GetDvar("is_speed"));

                    Utilities.FallDamage = Convert.ToInt32(GSCFunctions.GetDvar("is_falldamage")) > 0;
                });
            }
            return false;
        }
    }
}
