using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.LibraryManager
{
    public class LibraryManagerUtils
    {
        public void LaunchLibraryManager()
        {
            Process.Start("C:\\Users\\andrew.slavin\\OneDrive - Sage Software, Inc\\Bede\\repos\\BooksAPI\\BooksAPI\\LibraryManager\\LibraryManager.exe");
        }

        public void ExitLibraryManager()
        {
            //Process[] processlist = Process.GetProcesses();
        
            //foreach (Process theprocess in processlist)
            //{
            //    Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            //}

            foreach (var process in Process.GetProcessesByName("LibraryManager"))
            {
                process.Kill();
            }
        }
    }
}
