namespace project1_ref2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                app.Draw();                
                ConsoleKeyInfo info = Console.ReadKey();
                app.HandleKey(info);
            }
        }
    }
}