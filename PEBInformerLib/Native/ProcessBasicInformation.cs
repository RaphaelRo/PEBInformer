using System;
using System.Runtime.InteropServices;

namespace PEBInformerLib.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ProcessBasicInformation
    {
        public IntPtr ExitStatus;
        /// <summary>
        /// base address of the PEB structure
        /// </summary>
        public IntPtr PebBaseAddress;
        public IntPtr AffinityMask;
        public IntPtr BasePriority;
        public UIntPtr UniqueProcessId;
        public IntPtr InheritedFromUniqueProcessId;

        public int Size
        {
            get { return Marshal.SizeOf(typeof(ProcessBasicInformation)); }
        }
    }
}
