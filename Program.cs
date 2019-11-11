using System;
using System.Net;
using System.Threading;

namespace unbanChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string name = string.Empty;

            if (args.Length > 0)
                name = args[0];

            else
            {
                Console.WriteLine("id/username");
                name = Console.ReadLine();
            }

            while (true)
            {
                try
                {
                    string s = wc.DownloadString("https://old.ppy.sh/u/" + name);
                    if (s != null)
                    {
                        Console.WriteLine("Unbanned!! Congratulations, " + name + "!");
                        break;
                    }
                }

                catch
                {
                    Console.WriteLine("\nsnoozing :zzz:");
                    Thread.Sleep(500000);
                }
            }

            Console.ReadLine();
            wc.Dispose();
        }
    }
}
