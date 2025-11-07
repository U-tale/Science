using System;
using HarmonyLib;
using System.Configuration;
using Modding;
using MonoMod.RuntimeDetour;
using Satchel;
using Satchel.BetterMenus;

namespace ScienceMod
{
    public class ScienceMod : Mod, IGlobalSettings<NumbersOfEdits>, ICustomMenuMod
    {
        private static ScienceMod? _instance;

        internal static ScienceMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(ScienceMod)} was never constructed");
                }
                return _instance;
            }
        }

        

        public static NumbersOfEdits Nums { get; set; } = new NumbersOfEdits();



        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public ScienceMod() : base("MonoMod10")
        {
            _instance = this;
        }

        public override void Initialize()
        {
            // General Best Current Practice
            Log("Initializing");
 


            // Event Subscriptions
            int num = 0;
            while (num != 30)
            {
                if (num <= Nums.EventSubscriptions)
                {
                    On.HeroController.Awake += EventSubscriptionHere;
                }
                Log(num.ToString());
                num += 1;
            }
            var harmony = new Harmony("ScienceHarmony");
            // Prefixes
            if (Nums.HarmonyPrefixes >= 10) { harmony.PatchCategory("TenPatches"); }
            if (Nums.HarmonyPrefixes >= 10) { harmony.PatchCategory("TwentyPatches"); }
            if (Nums.HarmonyPrefixes >= 10) { harmony.PatchCategory("ThirtyPatches"); }
            if (Nums.HarmonyPrefixes >= 10) { harmony.PatchCategory("FortyPatches"); }

            Log("Initialized");
        }


        #region ModMenu

        private Menu? Menuref;

        public MenuScreen GetMenuScreen(MenuScreen modlistmenu, ModToggleDelegates? modtoggledelgates)
        {
            Menuref ??= new Menu(
                name: "Science",
                elements: new Element[]
                {
                    new HorizontalOption(
                        name: "Number of Events to subscribe to when loading Hollow Knight",
                        description: "",
                        values: new [] {"0", "10", "20", "30"},
                        applySetting: index => 
                        {
                            Nums.EventSubscriptions=index switch
                            {
                                0 => 0,
                                1 => 10,
                                2 => 20,
                                3 => 30,
                                _ => 0,
                            };
                        },
                        loadSetting: () => Nums.EventSubscriptions switch
                        {
                            0 => 0,
                            10 => 1,
                            20 => 2,
                            30 => 3,
                            _ => 0,
                        }
                        ),
                    new HorizontalOption(
                        name: "Number of Harmony prefixes to make when loading Hollow Knight",
                        description: "",
                        values: new [] {"0", "10", "20", "30"},
                        applySetting: index =>
                        {
                            Nums.HarmonyPrefixes=index switch
                            {
                                0 => 0,
                                1 => 10,
                                2 => 20,
                                3 => 30,
                                _ => 0,
                            };
                        },
                        loadSetting: () => Nums.HarmonyPrefixes switch
                        {
                            0 => 0,
                            10 => 1,
                            20 => 2,
                            30 => 3,
                            _ => 0,
                        }
                        ),
                    new HorizontalOption(
                        name: "Number of Harmony Postfixes to subscribe to when loading Hollow Knight",
                        description: "",
                        values: new [] {"0", "10", "20", "30"},
                        applySetting: index =>
                        {
                            Nums.HarmonyPostfixes=index switch
                            {
                                0 => 0,
                                1 => 10,
                                2 => 20,
                                3 => 30,
                                _ => 0,
                            };
                        },
                        loadSetting: () => Nums.HarmonyPostfixes switch
                        {
                            0 => 0,
                            10 => 1,
                            20 => 2,
                            30 => 3,
                            _ => 0,
                        }
                        )
                }
                );
            return Menuref.GetMenuScreen(modlistmenu);
        }

        public bool ToggleButtonInsideMenu {  get; }

        #endregion
        public void EventSubscriptionHere(On.HeroController.orig_Awake orig, HeroController self)
        {
            orig(self);
            Log("test");
        }

        #region globalsettings

        public void OnLoadGlobal(NumbersOfEdits num)
        {
            Nums = num;
        }

        public NumbersOfEdits OnSaveGlobal()
        {
            return Nums;
        }




        
    }
    public class NumbersOfEdits
    {
        public int? EventSubscriptions;
        public int? HarmonyPrefixes;
        public int? HarmonyPostfixes;
    }
    #endregion
    #region Harmony Prefixes
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixOne
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self){}
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixTwo
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixThree
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixFour
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixFive
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixSix
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixSeven
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixEight
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixNine
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TenPrefixes")]
    public class HarmonyPrefixTen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixEleven
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixTwelve
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixThirteen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixFourteen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixFifteen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixSixteen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixSeventeen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixEighteen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixNineteen
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("TwentyPrefixes")]
    public class HarmonyPrefixTwenty
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyOne
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyTwo
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyThree
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyFour
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyFive
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentySix
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentySeven
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyEight
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixTwentyNine
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("ThirtyPrefixes")]
    public class HarmonyPrefixThirty
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyOne
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyTwo
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyThree
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyFour
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyFive
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtySix
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtySeven
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyEight
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixThirtyNine
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    [HarmonyPatchCategory("FortyPrefixes")]
    public class HarmonyPrefixFourty
    {
        [HarmonyPatch(typeof(HeroController))]
        [HarmonyPatch(nameof(HeroController.SoulGain))]
        public void Prefix(HeroController self) { }
    }
    
    
    
    #endregion
}