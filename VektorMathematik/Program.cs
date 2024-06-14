namespace VektorMathematik
{
    internal class Program
    {
        Screen screen;
        Lobby lobby;

        static void Main(string[] args)
        {
            Screen screen = new Lobby();
            do
            {
                screen = screen.Start();
            } while (screen != null);
        }
    }
}
