using PEBInformerLib;
using PEBInformerLib.Native;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PEBInformerLib
{
    internal class ProcessMemoryReader
    {
        public static IntPtr GetPEBAddress(IntPtr hProc)
        {
            // Getting ProcessBasicInformation
            var processBasicInformation = NativeMethods.GetProcessBasicInformation(hProc);
            if (processBasicInformation.PebBaseAddress == IntPtr.Zero)
            {
                throw new InvalidOperationException("No Peb Address in ProcessBasicInformation");
            }
            return processBasicInformation.PebBaseAddress;
        }

        public object ReadCommandline(object hProc)
        {
            throw new NotImplementedException();
        }

        public static string ReadCommandline(IntPtr hProc)
        {
            IPeb peb = ReadStruct<Peb64>(hProc, GetPEBAddress(hProc));
            var processParameters = ReadStruct<RtlUserProcessParameters64>(hProc, peb.ProcessParameters);
            return ReadUnicodeString(hProc, processParameters.CommandLine.Buffer, processParameters.CommandLine.Length / 2);
        }

        public static T ReadStruct<T>(IntPtr hProc, IntPtr address) where T : struct
        {
            int bytesToRead = Marshal.SizeOf(typeof(T));
            IntPtr buffer = Marshal.AllocHGlobal(bytesToRead);
            byte[] dest = new byte[bytesToRead];
            try
            {
                ReadProcessMemory(hProc, address, dest, bytesToRead, out uint bytesRead);
                Marshal.Copy(dest, 0, buffer, (int)bytesRead);
                T result = (T)Marshal.PtrToStructure(buffer, typeof(T));
                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static string ReadUnicodeString(IntPtr hProc, IntPtr address, int characterCount)
        {
            IntPtr outBuffer = Marshal.AllocHGlobal(characterCount * 2);
            byte[] buffer = new byte[characterCount * 2];
            try
            {
                ReadProcessMemory(hProc, address, buffer, characterCount * 2, out uint bytesRead);
                Marshal.Copy(buffer, 0, outBuffer, (int)bytesRead);
                return Marshal.PtrToStringUni(outBuffer, (int)(bytesRead / 2));
            }
            finally
            {
                Marshal.FreeHGlobal(outBuffer);
            }
        }


        private static void ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out uint lpNumberOfBytesRead)
        {
            var success = NativeMethods.ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, nSize, out lpNumberOfBytesRead);
            if (!success)
            {
                var error = new Win32Exception(Marshal.GetLastWin32Error());
                throw new InvalidOperationException($"ReadProcessMemory {hProcess} error: \"{error.Message}\" occurred during the read from Address {(ulong)lpBaseAddress:X}.");
            }
        }

    }
}
