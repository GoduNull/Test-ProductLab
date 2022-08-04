using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Root
    {
        [JsonProperty("data")]
        public Data data { get; set; }
    }
}
