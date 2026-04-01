namespace RestWithASPNET10Erudio.Utils
{
    public class NumberHelper
    {

        public static bool TryConvertToDouble(string strNumber, out double result)
        {
            return double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out result
            );
        }

        public static bool TryConvertToDecimal(string strNumber, out decimal result)
        {
            return decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out result
            );
        }
    }
}

