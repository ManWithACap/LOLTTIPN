using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LOLTTIPN
{
    class ChampionsData
    {
        public Root root = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@"./selfdata/loldata/patch/data/en_US/championFull.json"));
        
        public class Root
        {
            public string type { get; set; }
            public string format { get; set; }
            public string version { get; set; }
            public Dictionary<string, Champion> data { get; set; }
            public Keys keys { get; set; }
        }

        public class Champion
        {
            public string id { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public ChampionImage image { get; set; }
            public List<ChampionSkins> skins { get; set; }
            public string lore { get; set; }
            public string blurb { get; set; }
            public List<string> allytips { get; set; }
            public List<string> enemytips { get; set; }
            public List<string> tags { get; set; }
            public string partype { get; set; }
            public Info info { get; set; }
            public Stats stats { get; set; }
            public List<Spells> spells { get; set; }
            public Passive passive { get; set; }
            public List<int> recommended { get; set; }
        }

        public class ChampionImage
        {
            public string full { get; set; }
            public string sprite { get; set; }
            public string group { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
        }

        public class ChampionSkins
        {
            public string id { get; set; }
            public int num { get; set; }
            public string name { get; set; }
            public bool chromas { get; set; }
        }

        public class Info
        {
            public int attack { get; set; }
            public int defense { get; set; }
            public int magic { get; set; }
            public int difficulty { get; set; }
        }

        public class Stats
        {
            public float hp { get; set; }
            public float hpperlevel { get; set; }
            public float mp { get; set; }
            public float mpperlevel { get; set; }
            public float movespeed { get; set; }
            public float armor { get; set; }
            public float armorperlevel { get; set; }
            public float spellblock { get; set; }
            public float spellblockperlevel { get; set; }
            public float attackrange { get; set; }
            public float hpregen { get; set; }
            public float hpregenperlevel { get; set; }
            public float mpregen { get; set; }
            public float mpregenperlevel { get; set; }
            public float crit { get; set; }
            public float critperlevel { get; set; }
            public float attackdamage { get; set; }
            public float attackdamageperlevel { get; set; }
            public float attackspeedperlevel { get; set; }
            public float attackspeed { get; set; }
        }

        public class Spells
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string tooltip { get; set; }
            public LevelTip leveltip { get; set; }
            public int maxrank { get; set; }
            public float[] cooldown { get; set; }
            public string cooldownBurn { get; set; }
            public int[] cost { get; set; }
            public string costBurn { get; set; }
            public DataValues datavalues { get; set; }
            public List<List<float>> effect { get; set; }
            public string[] effectBurn { get; set; }
            public string[] vars { get; set; }
            public string costType { get; set; }
            public string maxammo { get; set; }
            public int[] range { get; set; }
            public string rangeBurn { get; set; }
            public ChampionImage image { get; set; }
            public string resource { get; set; }
        }

        public class LevelTip
        {
            public string[] label { get; set; }
            public string[] effect { get; set; }
        }

        public class DataValues
        {

        }

        public class Passive
        {
            public string name { get; set; }
            public string description { get; set; }
            public ChampionImage image { get; set; }
        }

        public class Keys
        {
            public Dictionary<string, string> keys { get; set; }
        }
    }
}
