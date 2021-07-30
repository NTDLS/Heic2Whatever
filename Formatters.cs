namespace Heic2Whatever
{
    public static class Formatters
    {
        public const long KILOBYTE = 1024;
        public const long MEGABYTE = 1048576;
        public const long GIGABYTE = 1073741824;
        public const long TERABYTE = 1099511627776L;
        public const long PETABYTE = 1125899906842624L;
        public const long EXABYTE = 1152921504606847000L;

        public static string FormatFileSize(long? fileSize)
        {
            return FormatFileSize(fileSize, 2);
        }

        public static string FormatFileSize(long? fileSize, int decimalPlaces)
        {
            return FormatFileSize(fileSize, decimalPlaces, false);
        }

        public static string FormatFileSize(long? fileSize, int decimalPlaces, bool singleCharacterSuffix)
        {
            if (fileSize == null)
            {
                return string.Empty;

            }
            long divideBy = 1;
            string suffix = "";
            bool negative = false;

            if (fileSize < 0)
            {
                negative = true;
                fileSize *= -1;
            }

            if (fileSize >= EXABYTE)
            {
                divideBy = EXABYTE;
                suffix = "EB";
            }
            else if (fileSize >= PETABYTE)
            {
                divideBy = PETABYTE;
                suffix = "PB";
            }
            else if (fileSize >= TERABYTE)
            {
                divideBy = TERABYTE;
                suffix = "TB";
            }
            else if (fileSize >= GIGABYTE)
            {
                divideBy = GIGABYTE;
                suffix = "GB";
            }
            else if (fileSize >= MEGABYTE)
            {
                divideBy = MEGABYTE;
                suffix = "MB";
            }
            else if (fileSize >= KILOBYTE)
            {
                divideBy = KILOBYTE;
                suffix = "KB";
            }
            else
            {
                divideBy = 1;
                suffix = "B";
            }

            if (singleCharacterSuffix)
            {
                suffix = suffix.Substring(0, 1);
            }

            double friendlyFileSize = ((double)fileSize) / ((double)divideBy);

            if (negative)
            {
                friendlyFileSize *= -1;
            }

            return friendlyFileSize.ToString("N" + decimalPlaces.ToString()) + " " + suffix;
        }
    }
}
