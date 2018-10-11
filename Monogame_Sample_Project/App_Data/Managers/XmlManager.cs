using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Monogame_Sample_Project.App_Data.Managers
{
    public class XmlManager<T>
    {
        public Type Type;

        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(Type);
                instance = (T)xmlSerializer.Deserialize(reader);
            }
            return instance;
        }

        public void Save(string path, object serializable)
        {
            using(TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(Type);
                xmlSerializer.Serialize(writer, serializable);
            }
        }
    }
}
