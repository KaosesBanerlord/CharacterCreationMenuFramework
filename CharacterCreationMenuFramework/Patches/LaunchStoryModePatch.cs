using HarmonyLib;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.Objects;
using StoryMode;
using StoryMode.CharacterCreationContent;
using StoryMode.Quests.FirstPhase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace CharacterCreationMenuFramework.Patches
{
    [HarmonyPatch(typeof(StoryModeGameManager), "LaunchStoryModeCharacterCreation")]
    class LaunchStoryModePatch
    {
        private static void Postfix()
        {
            KaosesStoryModeCharacterCreationContent KaosesCharacterCreation = new KaosesStoryModeCharacterCreationContent();
            KaosesCharacterCreation.IsStoryMode = true;
            CharacterCreationState gameState = Game.Current.GameStateManager.CreateState<CharacterCreationState>(new object[]
            {
                KaosesCharacterCreation
            });
            Factory.KaosesCharacterCreation = KaosesCharacterCreation;
            Factory._CharacterCreationState = gameState;
            Factory.menuManager.CharacterCreation = gameState.CharacterCreation;

            Game.Current.GameStateManager.CleanAndPushState(gameState, 0);

        }
    }


    /*    // Token: 0x0600008D RID: 141 RVA: 0x00004B00 File Offset: 0x00002D00
        private void LaunchStoryModeCharacterCreation()
        {
            CharacterCreationState gameState = Game.Current.GameStateManager.CreateState<CharacterCreationState>(new object[]
            {
                    new StoryModeCharacterCreationContent()
            });
            Game.Current.GameStateManager.CleanAndPushState(gameState, 0);
        }*/
}
