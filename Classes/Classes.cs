
using System.Collections;

namespace Classes
{

    public class D2RConstants
    {
        public static string ScriptFileName = "scripts.json";
    }

    public class D2RScript
    {
        public int sId { get; set; }
        public string sName { get; set; }
        public ArrayList sActions { get; set; }

        public D2RScript(string name)
        {
            sName = name;
            sActions = new ArrayList();
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
        public int aKey { get; set; }
        public int aX { get; set; }
        public int aY { get; set; }

        public D2RScriptedAction()
        {
            aType = D2RScriptedActionTypes.MouseMove;
            aDelay = 250;
            aX = 0;
            aY = 0;
            aKey = 0;
        }
    }

}
