﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AssemblerLibrary.DataModels;
using AssemblerLibrary.InstructionSetModels;
using Core.Utils;

namespace Assembler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /**************************** Initialization Phase ******************************************/

            // initialize Symbol Table
            List<SymbolTable> symbolTable = new List<SymbolTable>()
            {
                new SymbolTable {Mnenomic = "SP", Address = 0},
                new SymbolTable {Mnenomic = "LCL", Address = 1},
                new SymbolTable {Mnenomic = "ARG", Address = 2},
                new SymbolTable {Mnenomic = "THIS", Address = 3},
                new SymbolTable {Mnenomic = "THAT", Address = 4},
                new SymbolTable {Mnenomic = "R0", Address = 0},
                new SymbolTable {Mnenomic = "R1", Address = 1},
                new SymbolTable {Mnenomic = "R2", Address = 2},
                new SymbolTable {Mnenomic = "R3", Address = 3},
                new SymbolTable {Mnenomic = "R4", Address = 4},
                new SymbolTable {Mnenomic = "R5", Address = 5},
                new SymbolTable {Mnenomic = "R6", Address = 6},
                new SymbolTable {Mnenomic = "R7", Address = 7},
                new SymbolTable {Mnenomic = "R8", Address = 8},
                new SymbolTable {Mnenomic = "R9", Address = 9},
                new SymbolTable {Mnenomic = "R10", Address = 10},
                new SymbolTable {Mnenomic = "R11", Address = 11},
                new SymbolTable {Mnenomic = "R12", Address = 12},
                new SymbolTable {Mnenomic = "R13", Address = 13},
                new SymbolTable {Mnenomic = "R14", Address = 14},
                new SymbolTable {Mnenomic = "R15", Address = 15},
                new SymbolTable {Mnenomic = "SCREEN", Address = 16384},
                new SymbolTable {Mnenomic = "KBD", Address = 24576}
            };

            // add more commands - incomming A Instructions
            // use loop to push them on the SymbolTable List
            // use rules and logic to assign symbols to appropiate memory addresses
            //symbolTable.Add(new SymbolTable { Mnenomic = "@i", Address = 16 });
            //symbolTable.Add(new SymbolTable { Mnenomic = "@sum", Address = 17 });
            //symbolTable.Add(new SymbolTable { Mnenomic = "(LOOP)", Address = 17 });

            //Console.WriteLine("SYMBOL Table values");
            //foreach (var symbolPair in symbolTable)
            //{
            //    Console.WriteLine("{0},  {1}", symbolPair.Mnenomic, symbolPair.Address);
            //}

            // Loop over pairs with foreach
            /*
            foreach(var symbolPair in _symbolTable){
                // find a memory address
                if(symbolPair.Mnenomic.Contains("KBD")){
                    Console.WriteLine("Memory Address {0}\n" , symbolPair.Address);
                }
            } */

            //This clears out the list so that it is
            //empty.
            //symbolTable.Clear();

            // initialize C-Instruction Table
            List<CInstructionSetTable> cInstructions = new List<CInstructionSetTable>()
            {
                // aBit=0
                new CInstructionSetTable {comp = "0", aBit = 0, c1 = 1, c2 = 0, c3 = 1, c4 = 0, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "1", aBit = 0, c1 = 1, c2 = 1, c3 = 1, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "-1", aBit = 0, c1 = 1, c2 = 1, c3 = 1, c4 = 0, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "D", aBit = 0, c1 = 0, c2 = 0, c3 = 1, c4 = 1, c5 = 0, c6 = 0},
                new CInstructionSetTable {comp = "A", aBit = 0, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 0, c6 = 0},
                new CInstructionSetTable {comp = "!D", aBit = 0, c1 = 0, c2 = 0, c3 = 1, c4 = 1, c5 = 0, c6 = 1},
                new CInstructionSetTable {comp = "!A", aBit = 0, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 0, c6 = 1},
                new CInstructionSetTable {comp = "-D", aBit = 0, c1 = 0, c2 = 0, c3 = 1, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "-A", aBit = 0, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "D+1", aBit = 0, c1 = 0, c2 = 1, c3 = 1, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "A+1", aBit = 0, c1 = 1, c2 = 1, c3 = 0, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "D-1", aBit = 0, c1 = 0, c2 = 0, c3 = 1, c4 = 1, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "A-1", aBit = 0, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "D+A", aBit = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "D-A", aBit = 0, c1 = 0, c2 = 1, c3 = 0, c4 = 0, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "A-D", aBit = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "D&A", aBit = 0, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0},
                new CInstructionSetTable {comp = "D|A", aBit = 0, c1 = 0, c2 = 1, c3 = 0, c4 = 1, c5 = 0, c6 = 1},
                // aBit=1
                new CInstructionSetTable {comp = "M", aBit = 1, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 0, c6 = 0},
                new CInstructionSetTable {comp = "!M", aBit = 1, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 0, c6 = 1},
                new CInstructionSetTable {comp = "-M", aBit = 1, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "M+1", aBit = 1, c1 = 1, c2 = 1, c3 = 0, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "M-1", aBit = 1, c1 = 1, c2 = 1, c3 = 0, c4 = 0, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "D+M", aBit = 1, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 1, c6 = 0},
                new CInstructionSetTable {comp = "D-M", aBit = 1, c1 = 0, c2 = 1, c3 = 0, c4 = 0, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "M-D", aBit = 1, c1 = 0, c2 = 0, c3 = 0, c4 = 1, c5 = 1, c6 = 1},
                new CInstructionSetTable {comp = "D&M", aBit = 1, c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0},
                new CInstructionSetTable {comp = "D|M", aBit = 1, c1 = 0, c2 = 1, c3 = 0, c4 = 1, c5 = 0, c6 = 1}
            };


            //Console.WriteLine("\nCOMP InstructionTable values");
            //Console.WriteLine(" comp    | a-bit | c1 | c2 | c3 | c4 | c5 | c6 ");
            //// Loop over cInstructionPair with foreach
            //foreach (var cInstructionPair in cInstructions)
            //{
            //    Console.WriteLine("   {0} " + "   |  {1}    | {2}  | {3}  | {4}  | {5}  | {6}  | {7}", cInstructionPair.comp.Trim(), cInstructionPair.aBit, cInstructionPair.c1, cInstructionPair.c2, cInstructionPair.c3, cInstructionPair.c4, cInstructionPair.c5, cInstructionPair.c6);
            //}

            // initialize dest-Instruction Table
            List<DestInstructionTable> destInstructionTable = new List<DestInstructionTable>()
            {
                new DestInstructionTable {Dest = "null", d1 = 0, d2 = 0, d3 = 0},
                new DestInstructionTable {Dest = "M", d1 = 0, d2 = 0, d3 = 1},
                new DestInstructionTable {Dest = "D", d1 = 0, d2 = 1, d3 = 0},
                new DestInstructionTable {Dest = "MD", d1 = 0, d2 = 1, d3 = 1},
                new DestInstructionTable {Dest = "A", d1 = 1, d2 = 0, d3 = 0},
                new DestInstructionTable {Dest = "AM", d1 = 1, d2 = 0, d3 = 1},
                new DestInstructionTable {Dest = "AD", d1 = 1, d2 = 1, d3 = 0},
                new DestInstructionTable {Dest = "AMD", d1 = 1, d2 = 1, d3 = 1}
            };


            //Console.WriteLine("\nDEST InstructionTable values");
            //Console.WriteLine(" dest      | d1 | d2 | d3 ");
            //// Loop over cInstructionPair with foreach
            //foreach (var destInstructionPair in destInstructionTable)
            //{
            //    Console.WriteLine("   {0}     " + "|  {1}  | {2}  | {3} ", destInstructionPair.Dest.Trim(), destInstructionPair.d1, destInstructionPair.d2, destInstructionPair.d3);
            //}

            // initialize jump-Instruction Table
            List<JumpInstructionTable> jumpInstructionTable = new List<JumpInstructionTable>()
            {
                new JumpInstructionTable {Jump = "null", j1 = 0, j2 = 0, j3 = 0},
                new JumpInstructionTable {Jump = "JGT", j1 = 0, j2 = 0, j3 = 1},
                new JumpInstructionTable {Jump = "JEQ", j1 = 0, j2 = 1, j3 = 0},
                new JumpInstructionTable {Jump = "JGE", j1 = 0, j2 = 1, j3 = 1},
                new JumpInstructionTable {Jump = "JLT", j1 = 1, j2 = 0, j3 = 0},
                new JumpInstructionTable {Jump = "JNE", j1 = 1, j2 = 0, j3 = 1},
                new JumpInstructionTable {Jump = "JLE", j1 = 1, j2 = 1, j3 = 0},
                new JumpInstructionTable {Jump = "JMP", j1 = 1, j2 = 1, j3 = 1}
            };


            //Console.WriteLine("\nJUMP InstructionTable values");
            //foreach (var e in jumpInstructionTable)
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}", e.Jump, e.j1, e.j2, e.j3);
            //    if (e.Jump.Equals("JLT"))
            //    {
            //        Console.WriteLine("Found conditional Jump instruction :{0}{1}{2}", e.j1, e.j2, e.j3);
            //    }
            //}


            /****************************[ Parsing Phase ]******************************************/

            //string asmReader = FileTools.ReadLineString(@"C:\Users\Darel\Desktop\nand2tetris\projects\06\Prog.asm");

            List<string> asmList = new List<string>();
            string path = (@"C:\Users\Darel\Desktop\nand2tetris\projects\06\Prog.asm");
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    var counter = 0;
                    var addressStart = 1024;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // clean data
                        if (SymbolCleaner(ref line)) continue;
                        
                        Match match2 = Regex.Match(line, @"/\A\D\w+|\A\w\D\D\D\w|\A\w\D|\A\w\=\w\+\w|\A\w\=\w\-\w/", RegexOptions.IgnoreCase);
                        if (match2.Success)
                        {
                            line = line.Replace(@"/\/+\s+\D*\W+\w+/", "");
                            // Add data to Symbol Table
                            if (line.StartsWith("(")) addressStart++;
                            symbolTable.Add(new SymbolTable { Mnenomic = line, Address = counter + addressStart });

                            counter++;
                        }
                    }
                }
            }
            catch (Exception e)
             {

                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
             }

            //Console.WriteLine("SYMBOL Table values");
            //foreach (var symbol in asmList)
            //{
            //    Console.WriteLine("Line:  {0}", symbol.Trim());
            //}

            Console.WriteLine("SYMBOL Table values");
            foreach (var symbolPair in symbolTable)
            {
                Console.WriteLine("{0},  {1}", symbolPair.Mnenomic, symbolPair.Address);
            }

            Console.ReadKey();
            /****************************[ Code Translation Phase ]*********************************/


            /******************************[ Assembling Phase ]***********************************/



            /****************************[ File Generation Phase ]*********************************/
            string binaryWriter = FileTools.WriteSingleLine(@"C:\Users\Darel\Desktop\nand2tetris\projects\06\Prog.hack");


            Console.ReadLine();
        }

        private static bool SymbolCleaner(ref string line)
        {
            if (line.StartsWith("/")) return true;
            Match match1 = Regex.Match(line, @"/\A\/+/", RegexOptions.IgnoreCase);
            
            if (match1.Success) return true;
            return false;
        }
    }
}
