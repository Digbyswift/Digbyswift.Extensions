namespace Digbyswift.Extensions
{
    public static class BooleanExtensions
    {

        public static string AsYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }
        
        public static string AsYesNo(this bool? source, string nullDefault)
        {
            if (!source.HasValue)
                return nullDefault;

            return source.Value ? "Yes" : "No";
        }

    }
}
