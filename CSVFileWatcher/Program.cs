using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CSVFileWatcher
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern void AllocConsole();
        static void Main()
        {
            var service = new CSVFileWatcherService();
            service.Directory = @"D:\CSV\";
            service.FilesMask = "*.csv";
            if (Environment.UserInteractive)
            {
                AllocConsole();
                Console.CancelKeyPress += (x, y) => service.Stop();
                service.Start();
                Console.ReadKey();
                service.Stop();
            }
            else
            {
                ServiceBase.Run(service);
            }
            
       }
    }
}
