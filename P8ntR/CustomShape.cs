using System.Windows.Shapes;
using System.Xml.Serialization;

namespace P8ntR
{

    [XmlInclude(typeof(CustomRectangle))]
    public class CustomShape
    {
        [XmlIgnore]
        public Shape Shape { get; set; }

    }

}
