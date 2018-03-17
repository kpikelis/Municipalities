using System.IO;
using System.Xml.Serialization;

namespace Municipalities.Common.Helpers
{
    public class FileReader
    {
        public static T DeserializeXmlFileToObject<T>(Stream streamToRead)
        {
            var xmlStream = new StreamReader(streamToRead);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(xmlStream);
        }
    }
}
