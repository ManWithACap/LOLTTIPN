using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace LOLTTIPN
{
    class ItemsData
    {
        public Root root = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@"./selfdata/loldata/patch/data/en_US/item.json"));

        public class ItemDetails
        {
            public string name { get; set; }
            public string description { get; set; }
            public string colloq { get; set; }
            public string plaintext { get; set; }
            public List<string> from { get; set; }
            public List<string> into { get; set; }
            public Image image { get; set; }
            public Gold gold { get; set; }
            public List<string> tags { get; set; }
            public Maps maps { get; set; }
            public Stats stats { get; set; }
            public int depth { get; set; }
        }


        public class Rune
        {
            public bool isrune { get; set; }
            public int tier { get; set; }
            public string type { get; set; }
        }

        public class Gold
        {
            public int @base { get; set; }
            public int total { get; set; }
            public int sell { get; set; }
            public bool purchasable { get; set; }
        }

        public class Stats
        {
            public double FlatHPPoolMod { get; set; }
            public double rFlatHPModPerLevel { get; set; }
            public double FlatMPPoolMod { get; set; }
            public double rFlatMPModPerLevel { get; set; }
            public double PercentHPPoolMod { get; set; }
            public double PercentMPPoolMod { get; set; }
            public double FlatHPRegenMod { get; set; }
            public double rFlatHPRegenModPerLevel { get; set; }
            public double PercentHPRegenMod { get; set; }
            public double FlatMPRegenMod { get; set; }
            public double rFlatMPRegenModPerLevel { get; set; }
            public double PercentMPRegenMod { get; set; }
            public double FlatArmorMod { get; set; }
            public double rFlatArmorModPerLevel { get; set; }
            public double PercentArmorMod { get; set; }
            public double rFlatArmorPenetrationMod { get; set; }
            public double rFlatArmorPenetrationModPerLevel { get; set; }
            public double rPercentArmorPenetrationMod { get; set; }
            public double rPercentArmorPenetrationModPerLevel { get; set; }
            public double FlatPhysicalDamageMod { get; set; }
            public double rFlatPhysicalDamageModPerLevel { get; set; }
            public double PercentPhysicalDamageMod { get; set; }
            public double FlatMagicDamageMod { get; set; }
            public double rFlatMagicDamageModPerLevel { get; set; }
            public double PercentMagicDamageMod { get; set; }
            public double FlatMovementSpeedMod { get; set; }
            public double rFlatMovementSpeedModPerLevel { get; set; }
            public double PercentMovementSpeedMod { get; set; }
            public double rPercentMovementSpeedModPerLevel { get; set; }
            public double FlatAttackSpeedMod { get; set; }
            public double PercentAttackSpeedMod { get; set; }
            public double rPercentAttackSpeedModPerLevel { get; set; }
            public double rFlatDodgeMod { get; set; }
            public double rFlatDodgeModPerLevel { get; set; }
            public double PercentDodgeMod { get; set; }
            public double FlatCritChanceMod { get; set; }
            public double rFlatCritChanceModPerLevel { get; set; }
            public double PercentCritChanceMod { get; set; }
            public double FlatCritDamageMod { get; set; }
            public double rFlatCritDamageModPerLevel { get; set; }
            public double PercentCritDamageMod { get; set; }
            public double FlatBlockMod { get; set; }
            public double PercentBlockMod { get; set; }
            public double FlatSpellBlockMod { get; set; }
            public double rFlatSpellBlockModPerLevel { get; set; }
            public double PercentSpellBlockMod { get; set; }
            public double FlatEXPBonus { get; set; }
            public double PercentEXPBonus { get; set; }
            public double rPercentCooldownMod { get; set; }
            public double rPercentCooldownModPerLevel { get; set; }
            public double rFlatTimeDeadMod { get; set; }
            public double rFlatTimeDeadModPerLevel { get; set; }
            public double rPercentTimeDeadMod { get; set; }
            public double rPercentTimeDeadModPerLevel { get; set; }
            public double rFlatGoldPer10Mod { get; set; }
            public double rFlatMagicPenetrationMod { get; set; }
            public double rFlatMagicPenetrationModPerLevel { get; set; }
            public double rPercentMagicPenetrationMod { get; set; }
            public double rPercentMagicPenetrationModPerLevel { get; set; }
            public double FlatEnergyRegenMod { get; set; }
            public double rFlatEnergyRegenModPerLevel { get; set; }
            public double FlatEnergyPoolMod { get; set; }
            public double rFlatEnergyModPerLevel { get; set; }
            public double PercentLifeStealMod { get; set; }
            public double PercentSpellVampMod { get; set; }
        }

        public class Maps
        {
            public bool _1 { get; set; }
            public bool _8 { get; set; }
            public bool _10 { get; set; }
            public bool _12 { get; set; }
            public bool _11 { get; set; }
            public bool _21 { get; set; }
            public bool _22 { get; set; }
        }

        public class Basic
        {
            public string name { get; set; }
            public Rune rune { get; set; }
            public Gold gold { get; set; }
            public string group { get; set; }
            public string description { get; set; }
            public string colloq { get; set; }
            public string plaintext { get; set; }
            public bool consumed { get; set; }
            public int stacks { get; set; }
            public int depth { get; set; }
            public bool consumeOnFull { get; set; }
            public List<object> from { get; set; }
            public List<object> into { get; set; }
            public int specialRecipe { get; set; }
            public bool inStore { get; set; }
            public bool hideFromAll { get; set; }
            public string requiredChampion { get; set; }
            public string requiredAlly { get; set; }
            public Stats stats { get; set; }
            public List<object> tags { get; set; }
            public Maps maps { get; set; }
        }

        public class Image
        {
            public string full { get; set; }
            public string sprite { get; set; }
            public string group { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
        }

        public class Group
        {
            public string id { get; set; }
            public string MaxGroupOwnable { get; set; }
        }

        public class Tree
        {
            public string header { get; set; }
            public List<string> tags { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public string version { get; set; }
            public Basic basic { get; set; }
            public List<Group> groups { get; set; }
            public List<Tree> tree { get; set; }

            public Dictionary<string, ItemDetails> data = new Dictionary<string, ItemDetails>();
        }
    }
}
