using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using BooksAPI.LibraryManager;

namespace BooksAPI.TestHooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
             
        [BeforeTestRun]
        public static void InitializeClient()
        {
            Console.WriteLine("** [BeforeTestRun]");
            LibraryManagerUtils libraryManager = new LibraryManagerUtils();
            libraryManager.LaunchLibraryManager();
        }

        [AfterTestRun]
        public static void ExitClient()
        {
            Console.WriteLine("** [AfterTestRun]");
            LibraryManagerUtils libraryManager = new LibraryManagerUtils();
            libraryManager.ExitLibraryManager();
        }
    }
}
