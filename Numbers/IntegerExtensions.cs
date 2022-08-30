using System;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {   
            var arr = new List<ComparisonSigns?>();
            return Check(number, arr);
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            var arr = new List<ComparisonSigns?>();
            return Type(number, arr);
        }

        public static string Type(long number, List<ComparisonSigns?> arr)
        {
            long sec = 0;
            long first = number;
            if (number.ToString(CultureInfo.InvariantCulture).Length == 1 || number.ToString(CultureInfo.InvariantCulture).Length == 2)
            {
                return "One digit number.";
            }

            if (number == long.MinValue)
            {
                return "Unordered.";
            }

            sec = first % 10;
            first = (first / 10) % 10;

            if (first > sec)
            {
                arr.Add(ComparisonSigns.MoreThan);
            }
            else if (first < sec)
            {
                arr.Add(ComparisonSigns.LessThan);
            }
            else if (first == sec)
            {
                arr.Add(ComparisonSigns.Equals);
            }

            if (number > 0)
            {
                Check(number / 10, arr);
            }

            int count_1 = 0;
            int count_2 = 0;
            int count_3 = 0;
            foreach (var item in arr)
            {
                if (item == ComparisonSigns.MoreThan)
                {
                    count_1++;
                }
                else if (item == ComparisonSigns.LessThan)
                {
                    count_2++;
                }
                else if (item == ComparisonSigns.Equals)
                {
                    count_3++;
                }
            }

            if (count_1 > 0 && count_2 > 0 && count_3 > 0)
            {
                return "Unordered.";
            }
            else if (count_1 > 0 && count_2 > 0 && count_3 == 0)
            {
                return "Unordered.";
            }
            else if (count_1 > 0 && count_2 == 0 && count_3 == 0)
            {
                return "Strictly Decreasing.";
            }
            else if (count_1 == 0 && count_2 > 0 && count_3 == 0)
            {
                return "Strictly Increasing.";
            }
            else if (count_1 == 0 && count_2 > 0 && count_3 > 0)
            {
                return "Increasing.";
            }
            else if (count_1 > 0 && count_2 == 0 && count_3 > 0)
            {
                return "Decreasing.";
            }
            else if (count_1 == 0 && count_2 == 0 && count_3 > 0)
            {
                return "Monotonous.";
            }

            return null;
        }
        
        public static ComparisonSigns? Check(long number, List<ComparisonSigns?> arr)
        {
            long sec = 0;
            long first = number;
            if (number.ToString(CultureInfo.InvariantCulture).Length == 1 || number.ToString(CultureInfo.InvariantCulture).Length == 2)
            {
                return null;
            }

            if (number == long.MinValue)
            {
                return ComparisonSigns.LessThan | ComparisonSigns.MoreThan | ComparisonSigns.Equals;
            }

            sec = first % 10;
            first = (first / 10) % 10;

            if (first > sec)
            {
                arr.Add(ComparisonSigns.MoreThan);
            }
            else if (first < sec)
            {
                arr.Add(ComparisonSigns.LessThan);
            }
            else if (first == sec)
            {
                arr.Add(ComparisonSigns.Equals);
            }

            if (number > 0)
            {
                Check(number / 10, arr);
            }
            
            int count_1 = 0;
            int count_2 = 0;
            int count_3 = 0;
            foreach (var item in arr)
            {
                if (item == ComparisonSigns.MoreThan)
                {
                    count_1++;
                }
                else if (item == ComparisonSigns.LessThan)
                {
                    count_2++;
                }
                else if (item == ComparisonSigns.Equals)
                {
                    count_3++;
                }
            }

            if (count_1 > 0 && count_2 > 0 && count_3 > 0)
            {
                return ComparisonSigns.LessThan | ComparisonSigns.MoreThan | ComparisonSigns.Equals;
            }
            else if (count_1 > 0 && count_2 > 0 && count_3 == 0)
            {
                return ComparisonSigns.LessThan | ComparisonSigns.MoreThan;
            }
            else if (count_1 > 0 && count_2 == 0 && count_3 == 0)
            {
                return ComparisonSigns.MoreThan;
            }
            else if (count_1 == 0 && count_2 > 0 && count_3 == 0)
            {
                return ComparisonSigns.LessThan;
            }
            else if (count_1 == 0 && count_2 > 0 && count_3 > 0)
            {
                return ComparisonSigns.LessThan | ComparisonSigns.Equals;
            }
            else if (count_1 > 0 && count_2 == 0 && count_3 > 0)
            {
                return ComparisonSigns.MoreThan | ComparisonSigns.Equals;
            }
            else if (count_1 == 0 && count_2 == 0 && count_3 > 0)
            {
                return ComparisonSigns.Equals;
            }

            return null;
        }
    }
}
