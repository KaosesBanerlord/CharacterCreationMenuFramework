using HarmonyLib;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.Objects;
using SandBox;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace CharacterCreationMenuFramework.Patches
{
    [HarmonyPatch(typeof(SandBoxGameManager), "LaunchSandboxCharacterCreation")]
    class LaunchSandboxModePatch
    {
        private static void Postfix()
        {
            KaosesStoryModeCharacterCreationContent KaosesCharacterCreation = new KaosesStoryModeCharacterCreationContent();
            CharacterCreationState gameState = Game.Current.GameStateManager.CreateState<CharacterCreationState>(new object[]
            {
                KaosesCharacterCreation
            });
            Factory.KaosesCharacterCreation = KaosesCharacterCreation;
            Factory._CharacterCreationState = gameState;
            Factory.menuManager.CharacterCreation = gameState.CharacterCreation;

            Game.Current.GameStateManager.CleanAndPushState(gameState, 0);

        }

        //private void LaunchSandboxCharacterCreation() => Game.Current.GameStateManager.CleanAndPushState((TaleWorlds.Core.GameState)Game.Current.GameStateManager.CreateState<CharacterCreationState>((object)new SandboxCharacterCreationContent()));

    }
}
