using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace StayFocused
{
    class Program
    {
        public static List<string> lines = File.ReadLines(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "whitelist.txt")).ToList();

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Stay Focused! Leaave this open in the background, and it will check that you are staying on task.");
            Console.WriteLine("Programs in the whitelist.txt file will not trigger an alert. If you are not using a program on the white list" +
                "for more than 5 minutes, an alert will popup");

            EventHandler();

        }

        static void EventHandler()
        {
            for (;;)
            {
                WindowWatch();

                int sleepTime = 300000;

                Stopwatch stopwatch = Stopwatch.StartNew();
                while (stopwatch.ElapsedMilliseconds < sleepTime)
                {
                    Console.WriteLine("Time remaining: {0}", sleepTime - stopwatch.ElapsedMilliseconds);
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        static bool WindowWatch()
        {
                StringBuilder builder = new StringBuilder(255);
                GetWindowText(GetForegroundWindow(), builder, 255);
                Console.WriteLine("Builder = " + builder);

                if (lines.Any(x => builder.ToString().Contains(x)))
                {
                    Console.WriteLine("Found a match");
                    return true;
                }
                else
                {
                    Console.WriteLine("no match found");
                    return false;
                }
            }
        }
}
