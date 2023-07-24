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

        public static DateOnly? TryParseDateOnly(string dateOnlyString)
        {
            try
            {
                var response = DateOnly.TryParse(dateOnlyString, out DateOnly result);

                if (response is false)
                    throw new FormatException("Bad format provided");

                return result;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }
    }
}