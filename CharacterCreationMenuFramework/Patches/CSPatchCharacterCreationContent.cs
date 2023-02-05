using HarmonyLib;
using KaosesCommon.Utils;
using CharacterCreationMenuFramework.CultureStart;
using CharacterCreationMenuFramework.Helpers;
using CharacterCreationMenuFramework.Objects;
using StoryMode.CharacterCreationContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace CharacterCreationMenuFramework.Patches
{
    public class CSPatchCharacterCreationContent
    {
        /*        [HarmonyPatch]
                public class CSPatchCharacterCreationInitialized
                {
                    private static IEnumerable<MethodBase> TargetMethods()
                    {
                        yield return AccessTools.Method(typeof(SandboxCharacterCreationContent), "OnInitialized");
                        yield return AccessTools.Method(typeof(StoryModeCharacterCreationContent), "OnInitialized");
                    }
                    protected static void Prefix(MethodBase __originalMethod, CharacterCreation characterCreation)
                    {
                        //CulturedStartCharacterCreationContent characterCreationContent = new CulturedStartCharacterCreationContent();
                        //characterCreationContent.AddTestMenu(characterCreation);


                    }

                    // Add the custom character creation menus.
                    protected static void Postfix(MethodBase __originalMethod, CharacterCreation characterCreation)
                    {
                        //CulturedStartCharacterCreationContent characterCreationContent = new CulturedStartCharacterCreationContent();
                        if (__originalMethod.DeclaringType == typeof(StoryModeCharacterCreationContent))
                        {
                            //characterCreationContent.AddQuestMenu(characterCreation);
                        }
                        if (!Harmony.HasAnyPatches("BannerKings"))
                        {
                            //~ skip cultured start options as bannerkings has its own
                            //characterCreationContent.AddStartMenu(characterCreation);
                        }
                        // characterCreationContent.AddLocationMenu(characterCreation);

                    }
                }

                [HarmonyPatch]
                public class CSPatchCharacterCreationFinalized
                {
                    private static IEnumerable<MethodBase> TargetMethods()
                    {
                        yield return AccessTools.Method(typeof(SandboxCharacterCreationContent), "OnCharacterCreationFinalized");
                        yield return AccessTools.Method(typeof(StoryModeCharacterCreationContent), "OnCharacterCreationFinalized");
                    }

                    //public static void Postfix() => CulturedStartAction.Apply(CulturedStartManager.Current.StoryOption, CulturedStartManager.Current.LocationOption);
                    public static void Postfix() => CulturedStartHelper.ApplyStartOptions();
                }


        */



    }
}
