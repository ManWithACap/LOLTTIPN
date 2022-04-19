using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LOLTTIPN
{
    class RunesData
    {

        public List<Category> root = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(@"./selfdata/loldata/patch/data/en_US/runesReforged.json")); 

        public class Rune
        {
            public int id { get; set; }
            public string key { get; set; }
            public string icon { get; set; }
            public string name { get; set; }
            public string shortDesc { get; set; }
            public string longDesc { get; set; }
        }

        public class Slot
        {
            public List<Rune> runes { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string key { get; set; }
            public string icon { get; set; }
            public string name { get; set; }
            public List<Slot> slots { get; set; }
        }
    }
}
