using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.AppInitializer;

namespace Assembler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize Application
            ApplicationConfig application = new ApplicationConfig();
            // Get CInstructionSetTable values (LOOP)
            var Comp = application.GetCInstructionSetTable.comp;
            var ABit = application.GetCInstructionSetTable.aBit;
            var C1 = application.GetCInstructionSetTable.c1;
            var C2 = application.GetCInstructionSetTable.c2;
            var C3 = application.GetCInstructionSetTable.c3;
            var C4 = application.GetCInstructionSetTable.c4;
            var C5 = application.GetCInstructionSetTable.c5;
            var C6 = application.GetCInstructionSetTable.c6;

            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", Comp, ABit, C1, C2, C3, C4, C5, C6);

            // Get DestInstructionTable values (LOOP)
            var Dest = application.GetDestInstructionTable.Dest;
            var D1 = application.GetDestInstructionTable.d1;
            var D2 = application.GetDestInstructionTable.d2;
            var D3 = application.GetDestInstructionTable.d3;
            
            // Get JumpInstructionTable values (LOOP)
            var Jump = application.GetJumpInstructionTable.Jump;
            var J1 = application.GetJumpInstructionTable.j1;
            var J2 = application.GetJumpInstructionTable.j2;
            var J3 = application.GetJumpInstructionTable.j3;

            // Get and Set SymbolTable values (LOOP)
            application.SetSymbolTable.Mnenomic = "@i";
            application.SetSymbolTable.Address = 16;
            application.SetSymbolTable.Mnenomic = "@sum";
            application.SetSymbolTable.Address = 17;
            application.SetSymbolTable.Mnenomic = "(LOOP)";
            application.SetSymbolTable.Address = 17;

            // Loop over pairs with foreach
            //foreach (var symbolPair in application.GetSymbolTable.A)
            //{
            //    Console.WriteLine("{0},  {1}", symbolPair., symbolPair.Address);
            //}

           

            Console.ReadLine();
        }
    }
}
