
namespace Classes
{
    public class MouseClickMessage
    {
        public int mX;
        public int mY;
        public int mButton;

        public MouseClickMessage(int x, int y, int button)
        {
            mX = x;
            mY = y;
            mButton = button;
        }
    }
}
