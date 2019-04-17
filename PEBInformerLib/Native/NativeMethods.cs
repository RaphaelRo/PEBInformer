using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    internal class NativeMethods
    {

        #region Open/Close


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            ProcessAccessFlags processAccess,
            bool bInheritHandle,
            int processId);


        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hHandle);

        #endregion

        #region NtQueryInformationProcess

        /// <summary>
        /// ZwQueryInformationProcess returns the PEB that matches the bitness of the calling process. 
        /// In the case where a 32-bit (WOW64) process attempts to retrieve the PEB of a native 64-bit process, 
        /// PROCESS_BASIC_INFORMATION. PebBaseAddress is NULL, since native 64-bit processes have no 32-bit PEB. 
        /// Also note that the 32-bit and 64-bit PEBs have different structure offsets, 
        /// so this method would have to be modified for a 64-bit process to successfully read from a 32-bit PEB.
        /// 
        /// **the PEB which pertains to 32-bit modules can be found by taking the 64bit PebBaseAddress and subtracting one page (0x1000) from its value**
        /// pic basic information = 0
        /// </summary>
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtQueryInformationProcess(IntPtr hProcess, int pic, ref ProcessBasicInformation pbi, int cb, out int pSize);


        public static ProcessBasicInformation GetProcessBasicInformation(IntPtr hProc)
        {
            var processBasicInformation = new ProcessBasicInformation();
            int queryStatus = NtQueryInformationProcess(hProc, 0, ref processBasicInformation, Marshal.SizeOf(typeof(ProcessBasicInformation)), out int size);
            if (queryStatus != 0)
            {
                throw new InvalidOperationException("Unable to get ProcessBasicInformation");
            }
            return processBasicInformation;
        }

        #endregion

        #region Wow64 Process

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);

        #endregion

        #region RPM

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out uint lpNumberOfBytesRead);

        #endregion

    }
}
