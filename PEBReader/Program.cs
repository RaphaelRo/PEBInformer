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
            Console.WriteLine("Enter process name:");
            var processName = Console.ReadLine();
            var process = Process.GetProcessesByName(processName).FirstOrDefault();
            using (var procmem = new ProcessMemory(process))
            {
                procmem.Open();
                Console.WriteLine(procmem.GetCommandLine());
            }
            Console.Read();
        }

    }
}
