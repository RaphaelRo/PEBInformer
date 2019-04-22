using PEBInformerLib;
using System;
using System.Diagnostics;
using System.Linq;

namespace PEBReader
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter process name:");
                var processName = Console.ReadLine();
                if (processName == "exit" || processName == "q")
                {
                    break;
                }
                var process = Process.GetProcessesByName(processName).FirstOrDefault();
                if (process == null)
                {
                    Console.WriteLine("Process not found.");
                    continue;
                }
                using (var procmem = new ProcessMemory(process))
                {
                    procmem.Open();
                    Console.WriteLine(procmem.GetCommandLine());
                }
            }
        }

    }
}
