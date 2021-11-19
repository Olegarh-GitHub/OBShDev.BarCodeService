using System;
using System.Collections.Generic;
using System.Linq;
using WPFFourthLaboratory.DAL.Models.Base;

namespace WPFFourthLaboratory.DAL.Models
{
    // ReSharper disable once InconsistentNaming
    public class EAN13BarCode : Base.BarCode
    {
        public int FirstDigit => int.Parse(Code[0].ToString());

        public EAN13BarCode(string code) 
        {
            if (code.Length != 13)
                throw new ArgumentException();

            Code = code;
            Draw();
        }

        public override string ToString()
        {
            var codeBlocks = GetCodeBlocks();
            return $"{FirstDigit} {string.Join("", codeBlocks[0])} {string.Join("", codeBlocks[1])}";
        }

        private int GetBlockNumber(int position)
        {
            if (position >= 6)
                return 3;

            var blocks = Mapper.GetBlock(FirstDigit);
            return blocks[position];
        }

        public override List<BarCodeModule> GetModules()
        {
            var codeBlocks = GetCodeBlocks();
            var modules = new List<BarCodeModule>();

            var position = 0;
            
            modules.Add(BarCodeModule.GetEmptyZone());
            modules.Add(BarCodeModule.GetGenericSeparator());
            
            foreach (var codeBlock in codeBlocks)
            {
                foreach (var digit in codeBlock)
                {
                    var blockNumber = GetBlockNumber(position);
                    position++;
                    var barCodeDigit = new BarCodeDigit(digit, blockNumber);
                    modules.Add(barCodeDigit);
                }
                modules.Add(BarCodeModule.GetMiddleSeparator());
            }
            modules.RemoveAt(modules.Count - 1); // pop last middle separator
            
            modules.Add(BarCodeModule.GetGenericSeparator());
            modules.Add(BarCodeModule.GetEmptyZone());

            return modules;
        }


        public List<int[]> GetCodeBlocks()
        {
            return new List<int[]>()
            {
                $"{Code.Substring(1, 6)}".ToList().Select(x => int.Parse(x.ToString())).ToArray(),
                $"{Code.Substring(7, 6)}".ToList().Select(x => int.Parse(x.ToString())).ToArray(),
            };
        }
    }
}