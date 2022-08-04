using Data.Models;
using Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class UiService
    {
        public static async Task RunAsync()
        {
            try
            {
                var keys = await ReadManager.ReadKeysAsync();
                var manager = new ParseManager();
                if (keys.Any())
                {
                    foreach (var key in keys)
                    {
                        WriteManager.WriteExel(await manager.GetRootAsync(key), key);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
