using System;
using System.Xml.Serialization;

namespace VetmanagerAPI
{
    public class SettingsResponse
    {
        readonly static XmlSerializer xmlSerializer = new(typeof(ServiceToken));

        //[JsonPropertyName("status")]
        public int? Status { get; set; }

        public string? Title { get; set; }

        public string? Detail { get; set; }

        public ServiceToken? Data { get; set; }

        public bool SaveInXML(string domainName)
        {
            if (Title == "Authorization completed." && Data is not null)
            {
                try
                {
                    Data.DomainName = domainName;
                    using FileStream fs = new("settings.xml", FileMode.OpenOrCreate);
                    xmlSerializer.Serialize(fs, Data);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;

        }

        public static ServiceToken? LoadFromXML()
        {
            try
            {
                using FileStream fs = new("settings.xml", FileMode.Open);
                return xmlSerializer.Deserialize(fs) as ServiceToken;
            }
            catch
            {
                return null;
            }
        }
    }
}