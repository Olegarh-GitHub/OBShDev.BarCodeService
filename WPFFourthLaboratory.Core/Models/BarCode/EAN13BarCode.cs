using System;
using System.Collections.Generic;
using System.Linq;
using WPFFourthLaboratory.DAL.Helpers;

namespace WPFFourthLaboratory.DAL.Models.BarCode
{
    public class EAN13BarCode : BarCode.Base.BarCode
    {
        private int FirstDigit => int.Parse(Code[0].ToString());

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
        
        protected override List<BarCodeModule> GetModules()
        {
            var codeBlocks = GetCodeBlocks();
            var modules = new List<BarCodeModule>();

            var position = 0;

            modules.Add(BarCodeSharedModules.GetEmptyZone());
            modules.Add(BarCodeSharedModules.GetGenericSeparator());
            
            foreach (var codeBlock in codeBlocks)
            {
                foreach (var digit in codeBlock)
                {
                    var blockNumber = GetBlockNumber(position);
                    position++;
                    var barCodeDigit = new BarCodeDigit(digit, blockNumber);
                    modules.Add(barCodeDigit);
                }
                modules.Add(BarCodeSharedModules.GetMiddleSeparator());
            }
            modules.RemoveAt(modules.Count - 1); // pop last middle separator
            
            modules.Add(BarCodeSharedModules.GetGenericSeparator());
            modules.Add(BarCodeSharedModules.GetEmptyZone());

            return modules;
        }

        private int GetBlockNumber(int position)
        {
            if (position >= 6)
                return 3;

            var blocks = BarCodeStripeWidthMapper.GetBlock(FirstDigit);
            return blocks[position];
        }

        private List<int[]> GetCodeBlocks()
        {
            return new List<int[]>()
            {
                $"{Code.Substring(1, 6)}".ToList().Select(x => int.Parse(x.ToString())).ToArray(),
                $"{Code.Substring(7, 6)}".ToList().Select(x => int.Parse(x.ToString())).ToArray(),
            };
        }
    }
}