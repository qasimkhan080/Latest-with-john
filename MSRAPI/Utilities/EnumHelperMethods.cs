using MSR.CORE.Logger;
using MSRDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSR.CORE.Utilities
{
    public static class EnumHelperMethods
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string response = string.Empty;
            try
            {
                var enumMember = enumValue.GetType()
                                    .GetMember(enumValue.ToString())
                                    .FirstOrDefault();

                if (enumMember != null)
                {
                    response = enumMember.GetCustomAttribute<DisplayAttribute>()?
                                     .GetName() ?? enumValue.ToString();
                }
                else
                {
                    response = enumValue.ToString();
                }

            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("EnumHelperMethods", "GetDisplayName", ex.Message, ex);
            }
            return response;
        }

        public static List<DropDownModel> EnumToList<T>()
        {
            var response = new List<DropDownModel>();
            try
            {
                var enumType = typeof(T);
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    var ddl = new DropDownModel();

                    var member = enumType.GetMember(item.ToString());
                    var attributes = member[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                    var displayName = attributes.Length > 0 ? ((DisplayAttribute)attributes[0]).Name : item.ToString();

                    if (displayName.ToLower() != "none" && displayName.ToLower() != "unknown")
                    {
                        ddl.Id = (int)item;
                        ddl.Name = displayName;
                        response.Add(ddl);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Logger.WriteException("EnumHelperMethods", "EnumToList", ex.Message, ex);
            }

            return response;
        }
    }
}
