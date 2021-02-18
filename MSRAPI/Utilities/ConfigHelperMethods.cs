using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.CORE.Utilities
{
    public class ConfigHelperMethods
    {
        public static bool GetConfigSettingAsBool(string key, bool defaultValue = false)
        {
            bool result = defaultValue;
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                if (value != null)
                {
                    result = Convert.ToBoolean(value);
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static int GetConfigSettingAsInt(string key, int defaultValue = 0)
        {
            int result = defaultValue;
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                if (value != null)
                {
                    int.TryParse(value, out result); 
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static string GetConfigSetting(string key, string defaultValue = "")
        {
            string result = defaultValue;
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                if (value != null)
                {
                    result = value;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
