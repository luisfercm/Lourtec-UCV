using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DisposePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaseDesechable c=null;
            try
            {
                c = new ClaseDesechable();

            }
            finally
            {
                c.Dispose();                
            }
            
            

            using (ClaseDesechable cv = new ClaseDesechable())
            {

            }
        }
    }

    public class ClaseDesechable : IDisposable
    {
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        MemoryStream stream = new MemoryStream();
        string s = "Blablabla";

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    stream.Dispose();
                    handle.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                s = null;
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ClaseDesechable() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
