using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class ReadManager
    {
        public async static Task<List<string>> ReadKeysAsync()
        {
            string? key;
            var keys = new List<string>();
            using (StreamReader reader = new StreamReader("Keys.txt"))
            {
                while ((key = await reader.ReadLineAsync()) != null)
                {
                   keys.Add(key);
                }
            }
            return keys;
        }
    }
}
