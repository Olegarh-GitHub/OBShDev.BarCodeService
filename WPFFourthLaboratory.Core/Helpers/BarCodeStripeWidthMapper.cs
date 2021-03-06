using System.Collections.Generic;

namespace WPFFourthLaboratory.DAL.Helpers
{
    public static class BarCodeStripeWidthMapper // TODO make block Enums
    {
        private static readonly Dictionary<int, Dictionary<int, int[]>> Map = new Dictionary<int, Dictionary<int, int[]>>()
        {
            {
                1, new Dictionary<int, int[]>()
                {
                    {0, new[] {3, 2, 1, 1}},
                    {1, new[] {2, 2, 2, 1}},
                    {2, new[] {2, 1, 2, 2}},
                    {3, new[] {1, 4, 1, 1}},
                    {4, new[] {1, 1, 3, 2}},
                    {5, new[] {1, 2, 3, 1}},
                    {6, new[] {1, 1, 1, 4}},
                    {7, new[] {1, 3, 1, 2}},
                    {8, new[] {1, 2, 1, 3}},
                    {9, new[] {3, 1, 1, 2}},
                }
            },
            {
                2, new Dictionary<int, int[]>()
                {
                    {0, new[] {1, 1, 2, 3}},
                    {1, new[] {1, 2, 2, 2}},
                    {2, new[] {2, 2, 1, 2}},
                    {3, new[] {1, 1, 4, 1}},
                    {4, new[] {2, 3, 1, 1}},
                    {5, new[] {1, 3, 2, 1}},
                    {6, new[] {4, 1, 1, 1}},
                    {7, new[] {2, 1, 3, 1}},
                    {8, new[] {3, 1, 2, 1}},
                    {9, new[] {2, 1, 1, 3}},
                }
            },
            {
                3, new Dictionary<int, int[]>()
                {
                    {0, new[] {3, 2, 1, 1}},
                    {1, new[] {2, 2, 2, 1}},
                    {2, new[] {2, 1, 2, 2}},
                    {3, new[] {1, 4, 1, 1}},
                    {4, new[] {1, 1, 3, 2}},
                    {5, new[] {1, 2, 3, 1}},
                    {6, new[] {1, 1, 1, 4}},
                    {7, new[] {1, 3, 1, 2}},
                    {8, new[] {1, 2, 1, 3}},
                    {9, new[] {3, 1, 1, 2}},
                }
            }
        };

        private static readonly Dictionary<int, int[]> BlockMap = new Dictionary<int, int[]>()
        {
            {0, new []{1, 1, 1, 1, 1, 1}},
            {1, new []{1, 1, 2, 1, 2, 2}},
            {2, new []{1, 1, 2, 2, 1, 2}},
            {3, new []{1, 1, 2, 2, 2, 1}},
            {4, new []{1, 2, 1, 1, 2, 2}},
            {5, new []{1, 2, 2, 1, 1, 2}},
            {6, new []{1, 2, 2, 2, 1, 1}},
            {7, new []{1, 2, 1, 2, 1, 2}},
            {8, new []{1, 2, 1, 2, 2, 1}},
            {9, new []{1, 2, 2, 1, 2, 1}},
        };

        public static int[] GetWidths(int blockNumber, int digit)
        {
            if (!Map.ContainsKey(blockNumber))
            {
                return default;
            }

            return !Map[blockNumber].ContainsKey(digit) ? default : Map[blockNumber][digit];
        }

        public static int[] GetBlock(int firstDigit)
        {
            return !BlockMap.ContainsKey(firstDigit) ? default : BlockMap[firstDigit];
        }
    }
}