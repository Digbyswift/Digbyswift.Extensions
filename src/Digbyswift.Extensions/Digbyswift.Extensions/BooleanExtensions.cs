namespace Digbyswift.Extensions
{
    public static class BooleanExtensions
    {

        public static string AsYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }
        
        public static string AsYesNo(this bool? source, string valueWhenNull)
        {
            if (!source.HasValue)
                return valueWhenNull;

            return source.Value ? "Yes" : "No";
        }

    }
}
