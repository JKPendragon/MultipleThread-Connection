using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace change_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Watcher();


        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Watcher()
        {

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection";
                watcher.NotifyFilter = NotifyFilters.LastWrite;

                watcher.Filter = "data.txt";
                watcher.Changed += OnChanged;
                watcher.EnableRaisingEvents = true;

                Console.ReadKey();

            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e) {
            Console.WriteLine("data hasbeen changed");
        }
        
    }
}
