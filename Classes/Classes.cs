
using System.Collections;

namespace Classes
{

    public class D2RConstants
    {
        public static string ScriptFileName = "scripts.json";
    }

    public class D2RScript
    {
        public int sId;
        public string sName;
        public ArrayList sActions;

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
        public int aType;
        public int aId;
        public int aDelay;
        public int aKey;
        public int aX;
        public int aY;

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
