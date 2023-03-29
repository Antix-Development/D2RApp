
/*
D2RApp - A MultiBoxing application for Diablo II Ressurrected.
Copyright (c) Cliff Earl, Antix Development, 2023.
MIT License.
*/

using System.Collections.Generic;

namespace Classes
{
    public class D2RConstants
    {
        public static string ScriptFileName = "scripts.json";
        public static int DefaultActionDelay = 250;
    }

    public class D2RScript
    {
        public int sId { get; set; }

        public string sName { get; set; }

        public List<D2RScriptedAction> sActions { get; set; }

        public D2RScript(string name)
        {
            sName = name;
            sActions = new List<D2RScriptedAction>();
        }
    }

    public class D2RScriptedActionTypes
    {
        public const int MouseMove = 0;
        public const int LeftClick = 1;
        public const int RightClick = 2;
        public const int KeyPress = 3;
    }

    public class D2RScriptedAction
    {
        public int aType { get; set; }
        public int aId { get; set; }
        public int aDelay { get; set; }
        public int aKey { get; set; } // Key
        public int aX { get; set; }
        public int aY { get; set; }

        public D2RScriptedAction()
        {
            aType = D2RScriptedActionTypes.MouseMove;
            aDelay = D2RConstants.DefaultActionDelay;
            aX = 0;
            aY = 0;
            aKey = 0;
        }
    }

}
