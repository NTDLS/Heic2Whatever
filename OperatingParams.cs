using ImageMagick;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Heic2Whatever
{
    public class OperatingParams
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MagickFormat Format { get; set; }
        public string Extension { get; set; }
        public string OutputPath { get; set; }
        public bool OverwriteExistingFiles { get; set; }

        public bool ResizeIfLargerThan { get; set; }
        public int ResizeIfLargerThanWidth { get; set; }
        public int ResizeIfLargerThanHeight { get; set; }

        public bool ResizeByPercentage { get; set; }
        public int ResizeByPercentageValue { get; set; }

        public bool ResizeToExactSize { get; set; }
        public int ResizeToExactSizeWidth { get; set; }
        public int ResizeToExactSizeHeight { get; set; }

        public int CPUThreadCount { get; set; }

        public static OperatingParams LoadFromRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.RegistryKey, false))
                {
                    if (key == null)
                    {
                        Registry.CurrentUser.CreateSubKey(Constants.RegistryKey);
                    }
                }

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.RegistryKey, false))
                {
                    var value = (string)key.GetValue("OperatingParams", "");
                    var result = JsonConvert.DeserializeObject<OperatingParams>(value);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            catch
            {
            }

            return new OperatingParams()
            {
                Format = MagickFormat.Jpg,
                CPUThreadCount = Environment.ProcessorCount,
                ResizeByPercentageValue = 100,
                ResizeToExactSizeHeight = 4000,
                ResizeToExactSizeWidth = 4000,
                OverwriteExistingFiles = false
            };
        }

        public static void SaveToRegistry(OperatingParams inst)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.RegistryKey, false))
                {
                    if (key == null)
                    {
                        Registry.CurrentUser.CreateSubKey(Constants.RegistryKey);
                    }
                }

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.RegistryKey, true))
                {
                    var json = JsonConvert.SerializeObject(inst);
                    key.SetValue("OperatingParams", json);
                }
            }
            catch
            {
            }
        }
    }
}
