using System.Collections.Generic;
using System.Reflection;

namespace CaptureTheChris.Web.Models
{
    public class FlagsDetailsModel
    {
        public Dictionary<string, bool> Flags;

        public FlagsDetailsModel(Flags.Flags flags)
        {
            Flags = new Dictionary<string, bool>();
            
            var properties = typeof(Flags.Flags).GetProperties();
            
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(bool))
                    Flags.Add(property.Name, (bool) property.GetValue(flags));
            }
        }
    }
}