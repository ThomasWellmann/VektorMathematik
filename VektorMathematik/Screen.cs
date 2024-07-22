namespace VektorMathematik
{
    internal abstract class Screen
    {
        public abstract Screen Start();
        protected void ResizeWindow(int _width = 100, int _height = 40)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(_width, _height);
            Console.SetBufferSize(_width, 1000);
        }
    }
}
