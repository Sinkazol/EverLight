using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EverLight.DTOs
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        [XmlIgnoreAttribute]
        public virtual  IEnumerable<Order> DoneOrders { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    
}
