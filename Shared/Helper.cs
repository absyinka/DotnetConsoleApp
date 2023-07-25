using System.Runtime.Intrinsics.X86;
namespace DotnetConsoleApp.Shared
{
    public static class Helper
    {
        public static string GenerateCode(int id)
        {
            return $"EMP-{id.ToString("0000")}";
        }

        public static int SelectEnum(string screenMessage, int validStart, int validEnd)
        {
            int outValue;

            do
            {
                Console.Write(screenMessage);
            } while (!(int.TryParse(Console.ReadLine(), out outValue) && IsValid(outValue, validStart, validEnd)));

            return outValue;
        }

        public static bool IsValid(int outValue, int start, int end)
        {
            return outValue >= start && outValue <= end;
        }

        public static DateOnly TryParseDateOnly(string dateOnlyString)
        {
            if (!DateOnly.TryParse(dateOnlyString, out DateOnly result))
            {
                throw new FormatException("Bad date only format provided!");
            }

            return result;
        }

        public static DateTime TryParseDateTime(string dateOnlyString)
        {
            if (!DateTime.TryParse(dateOnlyString, out DateTime result))
            {
                throw new FormatException("Bad datetime format provided!");
            }

            return result;
        }
    }
}