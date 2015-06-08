using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerLibrary.InstructionSetModels
{
    public class AInstruction : IDisposable
    {
        // Pointer to an external unmanaged resource. 
        private IntPtr handle;
        // Other managed resource this class uses. 
        private Component component = new Component();
        // Track whether Dispose has been called. 
        bool disposed = false;

        // Properties
        public int b0 { get; set; } // msb
        public int b1 { get; set; }
        public int b2 { get; set; }
        public int b3 { get; set; }
        public int b4 { get; set; }
        public int b5 { get; set; }
        public int b6 { get; set; }
        public int b7 { get; set; }
        public int b8 { get; set; }
        public int b9 { get; set; }
        public int b10 { get; set; }
        public int b11 { get; set; }
        public int b12 { get; set; }
        public int b13 { get; set; }
        public int b14 { get; set; }
        public int b15 { get; set; } // lsb

        // The class constructor. 
        public AInstruction() { }

        // The class constructor. 
        public AInstruction(IntPtr handle)
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
        ~AInstruction()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }
    }
}
