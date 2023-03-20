
namespace Classes
{
    public class ServerMessage
    {
        public string mType;
        public string mData;

        public ServerMessage(string type, string data)
        {
            mType = type;
            mData = data;
        }
    }
}
