using PEBInformerLib.Native;
using System;
using System.Diagnostics;

namespace PEBInformerLib
{
    public class ProcessMemory : IDisposable
    {
        private IntPtr _hProc;
        private bool _disposed;

        public ProcessMemory(Process process)
        {
            Process = process ?? throw new ArgumentNullException(nameof(process));
        }

        ~ProcessMemory()
        {
            Dispose(false);
        }

        public Process Process { get; }

        public void Open()
        {
            _hProc = NativeMethods.OpenProcess(ProcessAccessFlags.QueryInformation | ProcessAccessFlags.QueryLimitedInformation | ProcessAccessFlags.VirtualMemoryRead, false, Process.Id);
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public string GetCommandLine()
        {
            if (_hProc == IntPtr.Zero)
            {
                throw new InvalidOperationException("Process not opened");
            }
            return ProcessMemoryReader.ReadCommandline(_hProc);
        }

        public IPeb GetPeb()
        {
            if (_hProc == IntPtr.Zero)
            {
                throw new InvalidOperationException("Process not opened");
            }
            return ProcessMemoryReader.ReadStruct<Peb64>(_hProc, ProcessMemoryReader.GetPEBAddress(_hProc));
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            };

            if (disposing)
            {
                // Free managed objects here.
                //
            }
            // Free any unmanaged objects here.
            //

            //Close handle and free allocated memory
            NativeMethods.CloseHandle(_hProc);
            _hProc = IntPtr.Zero;
            _disposed = true;
        }

    }
}
