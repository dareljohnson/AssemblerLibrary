using System.Collections.Generic;
using System.Linq;
using AssemblerLibrary.DataModels;
using AssemblerLibrary.InstructionSetModels;

namespace Core.AppInitializer
{
    public class ApplicationConfig
    {
        // initialize Symbol Table
        List<SymbolTable> _symbolTable = new List<SymbolTable>
        {
            new SymbolTable { Mnenomic ="SP" ,Address = 0},
            new SymbolTable { Mnenomic ="LCL", Address = 1},
            new SymbolTable { Mnenomic ="ARG", Address = 2},
            new SymbolTable { Mnenomic ="THIS", Address = 3},
            new SymbolTable { Mnenomic ="THAT", Address = 4},
            new SymbolTable { Mnenomic ="R0", Address = 0},
            new SymbolTable { Mnenomic ="R1", Address = 1},
            new SymbolTable { Mnenomic ="R2", Address = 2},
            new SymbolTable { Mnenomic ="R3", Address = 3},
            new SymbolTable { Mnenomic ="R4", Address = 4},
            new SymbolTable { Mnenomic ="R5", Address = 5},
            new SymbolTable { Mnenomic ="R6", Address = 6},
            new SymbolTable { Mnenomic ="R7", Address = 7},
            new SymbolTable { Mnenomic ="R8", Address = 8},
            new SymbolTable { Mnenomic ="R9", Address = 9},
            new SymbolTable { Mnenomic ="R10", Address = 10},
            new SymbolTable { Mnenomic ="R11", Address = 11},
            new SymbolTable { Mnenomic ="R12", Address = 12},
            new SymbolTable { Mnenomic ="R13", Address = 13},
            new SymbolTable { Mnenomic ="R14", Address = 14},
            new SymbolTable { Mnenomic ="R15", Address = 15},
            new SymbolTable { Mnenomic ="SCREEN", Address = 16384},
            new SymbolTable { Mnenomic ="KBD", Address = 24576}
        };

        public SymbolTable GetSymbolTable => _symbolTable.FirstOrDefault(x => x.Mnenomic != null && (x.Address >= 0 || x.Address == 0));

        public SymbolTable SetSymbolTable
        {
            get { return _symbolTable.FirstOrDefault(x=>x.Mnenomic !=null && (x.Address >= 0 || x.Address == 0)); }
            set { _symbolTable.Add(value); }
        }

        // initialize C-Instruction Table
        List<CInstructionSetTable> _cInstructions = new List<CInstructionSetTable>(){
            // aBit=0
            new CInstructionSetTable { comp = "0", aBit = 0, c1 =1 ,c2=0, c3=1, c4=0 , c5=1, c6=0},
            new CInstructionSetTable { comp = "1", aBit = 0, c1 =1 ,c2=1, c3=1, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "-1", aBit = 0, c1 =1 ,c2=1, c3=1, c4=0 , c5=1, c6=0},
            new CInstructionSetTable { comp = "D", aBit = 0, c1 =0 ,c2=0, c3=1, c4=1 , c5=0, c6=0},
            new CInstructionSetTable { comp = "A", aBit = 0, c1 =1 ,c2=1, c3=0, c4=0 , c5=0, c6=0},
            new CInstructionSetTable { comp = "!D", aBit = 0, c1 =0 ,c2=0, c3=1, c4=1 , c5=0, c6=1},
            new CInstructionSetTable { comp = "!A", aBit = 0, c1 =1 ,c2=1, c3=0, c4=0 , c5=0, c6=1},
            new CInstructionSetTable { comp = "-D", aBit = 0, c1 =0 ,c2=0, c3=1, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "-A", aBit = 0, c1 =1 ,c2=1, c3=0, c4=0 , c5=1, c6=1},
            new CInstructionSetTable { comp = "D+1", aBit = 0, c1 =0 ,c2=1, c3=1, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "A+1", aBit = 0, c1 =1 ,c2=1, c3=0, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "D-1", aBit = 0, c1 =0 ,c2=0, c3=1, c4=1 , c5=1, c6=0},
            new CInstructionSetTable { comp = "A-1", aBit = 0, c1 =1 ,c2=1, c3=0, c4=0 , c5=1, c6=0},
            new CInstructionSetTable { comp = "D+A", aBit = 0, c1 =0 ,c2=0, c3=0, c4=0 , c5=1, c6=0},
            new CInstructionSetTable { comp = "D-A", aBit = 0, c1 =0 ,c2=1, c3=0, c4=0 , c5=1, c6=1},
            new CInstructionSetTable { comp = "A-D", aBit = 0, c1 =0 ,c2=0, c3=0, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "D&A", aBit = 0, c1 =0 ,c2=0, c3=0, c4=0 , c5=0, c6=0},
            new CInstructionSetTable { comp = "D|A", aBit = 0, c1 =0 ,c2=1, c3=0, c4=1 , c5=0, c6=1},
            // aBit=1
            new CInstructionSetTable { comp = "M", aBit = 1, c1 =1 ,c2=1, c3=0, c4=0 , c5=0, c6=0},
            new CInstructionSetTable { comp = "!M", aBit = 1, c1 =1 ,c2=1, c3=0, c4=0 , c5=0, c6=1},
            new CInstructionSetTable { comp = "-M", aBit = 1, c1 =1 ,c2=1, c3=0, c4=0 , c5=1, c6=1},
            new CInstructionSetTable { comp = "M+1", aBit = 1, c1 =1 ,c2=1, c3=0, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "M-1", aBit = 1, c1 =1 ,c2=1, c3=0, c4=0 , c5=1, c6=0},
            new CInstructionSetTable { comp = "D+M", aBit = 1, c1 =0 ,c2=0, c3=0, c4=0 , c5=1, c6=0},
            new CInstructionSetTable { comp = "D-M", aBit = 1, c1 =0 ,c2=1, c3=0, c4=0 , c5=1, c6=1},
            new CInstructionSetTable { comp = "M-D", aBit = 1, c1 =0 ,c2=0, c3=0, c4=1 , c5=1, c6=1},
            new CInstructionSetTable { comp = "D&M", aBit = 1, c1 =0 ,c2=0, c3=0, c4=0 , c5=0, c6=0},
            new CInstructionSetTable { comp = "D|M", aBit = 1, c1 =0 ,c2=1, c3=0, c4=1 , c5=0, c6=1}
        };

        public CInstructionSetTable GetCInstructionSetTable => _cInstructions.FirstOrDefault();

        public CInstructionSetTable SetCInstructionSetTable
        {
            get { return _cInstructions.FirstOrDefault(); }
            set { _cInstructions.Add(value); }
        }

        // initialize dest-Instruction Table
        List<DestInstructionTable> _destInstructionTable = new List<DestInstructionTable>(){
            new DestInstructionTable { Dest="null", d1=0, d2=0, d3=0},
            new DestInstructionTable { Dest="M", d1=0, d2=0, d3=1},
            new DestInstructionTable { Dest="D", d1=0, d2=1, d3=0},
            new DestInstructionTable { Dest="MD", d1=0, d2=1, d3=1},
            new DestInstructionTable { Dest="A", d1=1, d2=0, d3=0},
            new DestInstructionTable { Dest="AM", d1=1, d2=0, d3=1},
            new DestInstructionTable { Dest="AD", d1=1, d2=1, d3=0},
            new DestInstructionTable { Dest="AMD", d1=1, d2=1, d3=1}
        };

        public DestInstructionTable GetDestInstructionTable => _destInstructionTable.FirstOrDefault();

        public DestInstructionTable SetDestInstructionTable
        {
            get { return _destInstructionTable.FirstOrDefault(); }
            set { _destInstructionTable.Add(value); }
        }

        // initialize jump-Instruction Table
        List<JumpInstructionTable> _jumpInstructionTable = new List<JumpInstructionTable>(){
            new JumpInstructionTable { Jump="null", j1=0, j2=0, j3=0},
            new JumpInstructionTable { Jump="JGT", j1=0, j2=0, j3=1},
            new JumpInstructionTable { Jump="JEQ", j1=0, j2=1, j3=0},
            new JumpInstructionTable { Jump="JGE", j1=0, j2=1, j3=1},
            new JumpInstructionTable { Jump="JLT", j1=1, j2=0, j3=0},
            new JumpInstructionTable { Jump="JNE", j1=1, j2=0, j3=1},
            new JumpInstructionTable { Jump="JLE", j1=1, j2=1, j3=0},
            new JumpInstructionTable { Jump="JMP", j1=1, j2=1, j3=1}
        };
        public JumpInstructionTable GetJumpInstructionTable => _jumpInstructionTable.FirstOrDefault();

        public JumpInstructionTable SetJumpInstructionTable
        {
            get { return _jumpInstructionTable.FirstOrDefault(); }
            set { _jumpInstructionTable.Add(value); }
        }
    }

}
