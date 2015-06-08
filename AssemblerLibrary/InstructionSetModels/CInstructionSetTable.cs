using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerLibrary.InstructionSetModels
{
    // C-InstructionSet for readonly
    public class CInstructionSetTable : IDisposable
    {
        // Pointer to an external unmanaged resource. 
        private IntPtr handle;
        // Other managed resource this class uses. 
        private Component component = new Component();
        // Track whether Dispose has been called. 
        bool disposed = false;

        // Properties
        public int aBit { get; set; }
        public string comp { get; set; }
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c4 { get; set; }
        public int c5 { get; set; }
        public int c6 { get; set; }

        // The class constructor. 
        public CInstructionSetTable() { }

        // The class constructor. 
        public CInstructionSetTable(IntPtr handle)
        {
            this.handle = handle;
        }

        // Implement IDisposable. 
        // Do not make this method virtual. 
        // A derived class should not be able to override this method. 
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                // Dispose managed resources.
                component.Dispose();
            }

            // Call the appropriate methods to clean up 
            // unmanaged resources here. 
            // If disposing is false, 
            // only the following code is executed.
            CloseHandle(handle);
            handle = IntPtr.Zero;

            // Note disposing has been done.
            disposed = true;
        }
        // Use interop to call the method necessary 
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code. 
        // This destructor will run only if the Dispose method 
        // does not get called. 
        // It gives your base class the opportunity to finalize. 
        // Do not provide destructors in types derived from this class.
        ~CInstructionSetTable()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }
    }
}
