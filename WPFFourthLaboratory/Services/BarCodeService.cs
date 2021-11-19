using System.Collections.Generic;
using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.DAL.Services;

namespace WPFFourthLaboratory.Services
{
    public class BarCodeService : IBarCodeService
    {
        private readonly BarCodeStripeWidthMapper _mapper;

        public BarCodeService()
        {
            _mapper = new BarCodeStripeWidthMapper();
        }

        public BarCode GenerateBarCode(Goods goods)
        {
            var result = $"{goods.Country.Code}";
            result += goods.Producer.Code;
            result += goods.Code;
            return GenerateBarCode(result);
        }

        public BarCode GenerateBarCode(string code)
        {
            code += GetCheckDigit(code);
            return new BarCode() {Code = code};
        }

        private static int GetCheckDigit(string code)
        {
            var oddSum = 0;
            var evenSum = 0;

            for (var i = 0; i < code.Length; i++)
            {
                var digit = int.Parse(code[i].ToString());
                if ((i + 1) % 2 == 0)
                {
                    evenSum += digit;
                }
                else
                {
                    oddSum += digit;
                }
            }

            evenSum *= 3;
            var result = oddSum + evenSum;
            var resultDigit = result.ToString()[result.ToString().Length - 1];
            return 10 - int.Parse(resultDigit.ToString());
        }

        public bool CheckBarCode(BarCode barCode)
        {
            var barCodeLength = barCode.Code.Length;
            var code = barCode.Code.Remove(barCodeLength - 1);
            var checkDigit = barCode.Code.Remove(0, barCodeLength - 1);
            return GetCheckDigit(code).ToString() == checkDigit;
        }

        private int[] EncodeDigit(int digit, int block)
        {
            return _mapper.GetWidths(block + 1, digit);
        }

        public List<int[]> GetWidths(BarCode barCode)
        {
            var blocks = barCode.Blocks;
            var result = new List<int[]>();

            for (var i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];
                foreach (var digit in block)
                {
                    var widths = EncodeDigit(int.Parse(digit.ToString()), i);
                    result.Add(widths);
                }
            }

            return result;
        }
    }
}