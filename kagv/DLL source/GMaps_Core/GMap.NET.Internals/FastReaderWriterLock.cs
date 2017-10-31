
namespace GMap.NET.Internals {
    using System;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// custom ReaderWriterLock
    /// in Vista and later uses integrated Slim Reader/Writer (SRW) Lock
    /// http://msdn.microsoft.com/en-us/library/aa904937(VS.85).aspx
    /// http://msdn.microsoft.com/en-us/magazine/cc163405.aspx#S2
    /// </summary>
    public sealed class FastReaderWriterLock : IDisposable {

        private static class NativeMethods {
            // Methods
            [DllImport("Kernel32", ExactSpelling = true)]
            internal static extern void AcquireSRWLockExclusive(ref IntPtr srw);
            [DllImport("Kernel32", ExactSpelling = true)]
            internal static extern void AcquireSRWLockShared(ref IntPtr srw);
            [DllImport("Kernel32", ExactSpelling = true)]
            internal static extern void InitializeSRWLock(out IntPtr srw);
            [DllImport("Kernel32", ExactSpelling = true)]
            internal static extern void ReleaseSRWLockExclusive(ref IntPtr srw);
            [DllImport("Kernel32", ExactSpelling = true)]
            internal static extern void ReleaseSRWLockShared(ref IntPtr srw);
        }

        IntPtr LockSRW = IntPtr.Zero;

        public FastReaderWriterLock() {

            var proc = System.Diagnostics.Process.GetCurrentProcess();
            int coreFlag;
            if (Environment.ProcessorCount == 1) coreFlag = 0x0001;
            else if (Environment.ProcessorCount == 2) coreFlag = 0x0003;
            else if (Environment.ProcessorCount == 3) coreFlag = 0x0007;
            else coreFlag = 0x000F; //use only 4 cores.We dont care for pcs with more than 4 cores.

            proc.ProcessorAffinity = new IntPtr(coreFlag);

            if (UseNativeSRWLock) {
                NativeMethods.InitializeSRWLock(out this.LockSRW);
            } else {
                pLock = new FastResourceLock();
            }
        }
        
        ~FastReaderWriterLock() {
            Dispose(false);
        }

        void Dispose(bool disposing) {
            if (pLock != null) {
                pLock.Dispose();
                pLock = null;
            }
        }

        FastResourceLock pLock;

        static readonly bool UseNativeSRWLock = Stuff.IsRunningOnVistaOrLater() && IntPtr.Size == 4; // works only in 32-bit mode, any ideas on native 64-bit support? 

        Int32 busy = 0;
        Int32 readCount = 0;

        public void AcquireReaderLock() {
            if (UseNativeSRWLock) {
                NativeMethods.AcquireSRWLockShared(ref LockSRW);
            } else {
                pLock.AcquireShared();
            Thread.BeginCriticalRegion();

            while(Interlocked.CompareExchange(ref busy, 1, 0) != 0)
            {
               Thread.Sleep(1);
            }

            Interlocked.Increment(ref readCount);

            // somehow this fix deadlock on heavy reads
            Thread.Sleep(0);
            Thread.Sleep(0);
            Thread.Sleep(0);
            Thread.Sleep(0);
            Thread.Sleep(0);
            Thread.Sleep(0);
            Thread.Sleep(0);

            Interlocked.Exchange(ref busy, 0);

            }
        }

        public void ReleaseReaderLock() {
            if (UseNativeSRWLock) 
                NativeMethods.ReleaseSRWLockShared(ref LockSRW);
            else 
                pLock.ReleaseShared();
        }

        public void AcquireWriterLock() {
            if (UseNativeSRWLock) 
                NativeMethods.AcquireSRWLockExclusive(ref LockSRW);
            else
                pLock?.AcquireExclusive();
        }

        public void ReleaseWriterLock() {
            if (UseNativeSRWLock)
                NativeMethods.ReleaseSRWLockExclusive(ref LockSRW);
            else
                pLock?.ReleaseExclusive();
            
        }

        #region IDisposable Members

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
