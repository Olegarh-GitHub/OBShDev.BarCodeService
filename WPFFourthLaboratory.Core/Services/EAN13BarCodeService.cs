using WPFFourthLaboratory.DAL.Interfaces;
using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.DAL.Models.BarCode.Base;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.Services
{
    public class EAN13BarCodeService : IBarCodeService
    {
        public string GenerateBarCode(Product product)
        {
            var result = $"{product.Country.Code}";
            result += product.Producer.Code;
            result += product.Code;
            
            return GenerateBarCode(result);
        }

        public string GenerateBarCode(string code)
        {
            code += GetCheckDigit(code);
            return code;
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
            var result = (oddSum + evenSum).ToString();
            var resultDigit = result[result.Length - 1];

            return 10 - int.Parse(resultDigit.ToString());
        }

        public bool CheckBarCode(string code)
        {
            var barCodeLength = code.Length;
            var barCodeWithoutCheckDigit = code.Remove(barCodeLength - 1);
            var checkDigit = barCodeWithoutCheckDigit.Remove(0, barCodeLength - 1);
            
            return GetCheckDigit(code).ToString() == checkDigit;
        }
    }
}