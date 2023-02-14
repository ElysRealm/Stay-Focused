using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Stay_Focused
{
    internal class Program
    {

        public static List<string> lines = File.ReadLines(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "whitelist.txt")).ToList();

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        public static StayFocused stayfocused = new StayFocused(); //initializing the StayFocused class from Form1.cs

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StayFocused());

            EventHandler();

            System.Windows.Forms.MessageBox.Show("Aye I'm debuggin here!");

            //TODO make this shit work, lol. Call Program to make sure it is doing shit.
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
                    stayfocused.timeUntil.Text = "test";
                    Console.WriteLine("Time until next check: {0}", sleepTime - stopwatch.ElapsedMilliseconds);
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