using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.StartObj;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;

namespace CharacterCreationMenuFramework.Interfaces
{
    public interface ICustomMenu
    {

        string Id { get; }
        public TextObject title { get; }
        public TextObject description { get; }
        public menuOperationMode OperationMode { get; }
        public Operationposition OperationPosition { get; }
        public string OperationmenuId { get; }
        public CharacterCreationOnInit CreationOnInit { get; }
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions { get; }
        public List<CMenuOption> OptionsList { get; }
        public string textVariable { get; }
        public int variableValue { get; }

        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent);

        //public void RegisterMenu(MenuManager menuManager);

        //public void RegisterOptions(MenuManager menuManager);

    }
}
