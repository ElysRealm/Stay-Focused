using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StayFocused // Note: actual namespace depends on the project name.
{
    class Program
    {
        public static List<string> lines = System.IO.File.ReadLines("C:\\Users\\eb199\\source\\repos\\Stay Focused\\whitelist.txt").ToList();

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Stay Focused! Leaave this open in the background, and it will check that you are staying on task.");
            Console.WriteLine("Programs in the whitelist.txt file will not trigger an alert. If you are not using a program on the white list" +
                "for more than 5 minutes, an alert will popup");

            WindowWatch();

        }

        static void WindowWatch()
        {
            System.Threading.Thread.Sleep(2000);
            StringBuilder builder = new StringBuilder(255);
            GetWindowText(GetForegroundWindow(), builder, 255);
            Console.WriteLine("Builder = " + builder);
            System.Threading.Thread.Sleep(2000);
            if (lines.Any(x => builder.ToString().Contains(x)))
            {
                Console.WriteLine("Found a match");
            }
            else
            {
                Console.WriteLine("No match found.");
                MessageBox.Show("Shouldn't you be doing some more productive?");
                System.Threading.Thread.Sleep(300000);
                WindowWatch();
            }

            //check if any part of builder matches against the lines list.
        }
    }
}