using Controllers;
using Views;

namespace ConsoleTest
{
    class Program
    {
        static void Main()
        {
            ConsoleView view = new ConsoleView(new BookController());
            view.Start();
        }
    }
}
