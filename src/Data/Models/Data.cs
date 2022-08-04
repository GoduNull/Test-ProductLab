using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Data
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}
