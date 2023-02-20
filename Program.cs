using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;

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

            Task.Run(() => EventHandler());

            Application.Run(stayfocused);

        }

        static void EventHandler()
        {
            try
            {
                for (;;)
                {
                    System.Threading.Thread.Sleep(100); //seems to be needed to prevent an exception :clown:
                    int sleepTime = 300000;

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    while (stopwatch.ElapsedMilliseconds < sleepTime)
                    {
                        long res = sleepTime - stopwatch.ElapsedMilliseconds;
                        string resString = res.ToString();
                        stayfocused.timeUntil.Invoke((Action)(() => stayfocused.timeUntil.Text = resString));
                        //use Control.Invoke to update the UI from the same thread that created the control
                        //this is necessary because UI controls can only be accessed from the thread that created them
                        System.Threading.Thread.Sleep(100);
                    }

                    WindowWatch();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An exception occurred: {ex.Message}");
            }
            
        }

        static bool WindowWatch()
        {
            StringBuilder builder = new StringBuilder(255);
            GetWindowText(GetForegroundWindow(), builder, 255);
            Console.WriteLine("Builder = " + builder);

            if (lines.Any(x => builder.ToString().Contains(x)))
            {
                Debug.WriteLine("Found a match");
                stayfocused.Invoke((MethodInvoker)delegate {
                    MessageBox.Show("Looks like you're staying on task, good job!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                });

                return true;
            }
            else
            {
                Debug.WriteLine("no match found, alerting user");
                stayfocused.Invoke((MethodInvoker)delegate {
                    MessageBox.Show("It looks like you're off task! Try to refocus on your work.", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                });
                return false;
            }
        }
    }
}