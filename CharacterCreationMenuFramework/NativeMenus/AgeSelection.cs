using CharacterCreationMenuFramework.Interfaces;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.StartObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;
using static TaleWorlds.MountAndBlade.SpawnerEntityEditorHelper;

namespace CharacterCreationMenuFramework.NativeMenus
{
    public class AgeSelection : ICustomMenu
    {
        public string Id => "native_ageslection";

        public TextObject title => new TextObject("{=HDFEAYDk}Native Starting Age");

        public TextObject description => new TextObject("{=VlOGrGSn}Your character started off on the adventuring path at the age of...");

        public Enums.menuOperationMode OperationMode => menuOperationMode.Add;

        public Enums.Operationposition OperationPosition => Operationposition.Default;

        public string OperationmenuId => "";

        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.StartingAgeOnInit);

        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;

        public string textVariable => "EXP_VALUE";

        public int variableValue => 10;


        public int StartingAge = 20;
        public int StartingYoungAdultAge = 20; //20
        public int StartingAdultAge = 30; //30
        public int StartingMiddleAgedAge = 40; //40
        public int StartingElderAge = 50; //50


        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            StartingAge = characterCreationContent.SandboxStartingAge;
            StartingYoungAdultAge = characterCreationContent.SandboxStartingYoungAdultAge;
            StartingAdultAge = characterCreationContent.SandboxStartingAdultAge;
            StartingMiddleAgedAge = characterCreationContent.SandboxStartingMiddleAgedAge;
            StartingElderAge = characterCreationContent.SandboxStartingElderAge;

            BuildMenuOptions(characterCreation, characterCreationContent);
        }

        protected void BuildMenuOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            CMenuOption menuStartingAgeYoung = new CMenuOption(new TextObject("{=!}" + this.StartingYoungAdultAge), new TextObject("{=2k7adlh7}While lacking experience a bit, you are full with youthful energy, you are fully eager, for the long years of adventuring ahead."));
            menuStartingAgeYoung.effectedSkills = new MBList<SkillObject>(); //MBList<SkillObject>
            menuStartingAgeYoung.effectedAttribute = (CharacterAttribute)null; //CharacterAttribute
            menuStartingAgeYoung.focusToAdd = 0;
            menuStartingAgeYoung.skillLevelToAdd = 0;
            menuStartingAgeYoung.attributeLevelToAdd = 0;
            menuStartingAgeYoung.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuStartingAgeYoung.onSelect = new CharacterCreationOnSelect(this.StartingAgeYoungOnConsequence);//CharacterCreationOnSelect
            menuStartingAgeYoung.onApply = new CharacterCreationApplyFinalEffects(this.StartingAgeYoungOnApply);//CharacterCreationApplyFinalEffects
            menuStartingAgeYoung.unspentFocusPoint = 2;
            menuStartingAgeYoung.unspentAttributePoint = 1;
            menuStartingAgeYoung.Id = "na_startingageyoung";

            CMenuOption menuStartingAgeAdult = new CMenuOption(new TextObject("{=!}" + this.StartingAdultAge), new TextObject("{=NUlVFRtK}You are at your prime, You still have some youthful energy but also have a substantial amount of experience under your belt. "));
            menuStartingAgeAdult.effectedSkills = new MBList<SkillObject>(); //MBList<SkillObject>
            menuStartingAgeAdult.effectedAttribute = (CharacterAttribute)null; //CharacterAttribute
            menuStartingAgeAdult.focusToAdd = 0;
            menuStartingAgeAdult.skillLevelToAdd = 0;
            menuStartingAgeAdult.attributeLevelToAdd = 0;
            menuStartingAgeAdult.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuStartingAgeAdult.onSelect = new CharacterCreationOnSelect(this.StartingAgeAdultOnConsequence);//CharacterCreationOnSelect
            menuStartingAgeAdult.onApply = new CharacterCreationApplyFinalEffects(this.StartingAgeAdultOnApply);//CharacterCreationApplyFinalEffects
            menuStartingAgeAdult.unspentFocusPoint = 4;
            menuStartingAgeAdult.unspentAttributePoint = 2;
            menuStartingAgeAdult.Id = "na_startingageadult";

            CMenuOption menuStartingAgeMiddleAged = new CMenuOption(new TextObject("{=!}" + this.StartingMiddleAgedAge), new TextObject("{=5MxTYApM}This is the right age for starting off, you have years of experience, and you are old enough for people to respect you and gather under your banner."));
            menuStartingAgeMiddleAged.effectedSkills = new MBList<SkillObject>(); //MBList<SkillObject>
            menuStartingAgeMiddleAged.effectedAttribute = (CharacterAttribute)null; //CharacterAttribute
            menuStartingAgeMiddleAged.focusToAdd = 0;
            menuStartingAgeMiddleAged.skillLevelToAdd = 0;
            menuStartingAgeMiddleAged.attributeLevelToAdd = 0;
            menuStartingAgeMiddleAged.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuStartingAgeMiddleAged.onSelect = new CharacterCreationOnSelect(this.StartingAgeMiddleAgedOnConsequence);//CharacterCreationOnSelect
            menuStartingAgeMiddleAged.onApply = new CharacterCreationApplyFinalEffects(this.StartingAgeMiddleAgedOnApply);//CharacterCreationApplyFinalEffects
            menuStartingAgeMiddleAged.unspentFocusPoint = 6;
            menuStartingAgeMiddleAged.unspentAttributePoint = 3;
            menuStartingAgeMiddleAged.Id = "na_startingagemiddleAged";

            CMenuOption menuStartingAgeElderly = new CMenuOption(new TextObject("{=!}" + this.StartingElderAge), new TextObject("{=ePD5Afvy}While you are past your prime, there is still enough time to go on that last big adventure for you. And you have all the experience you need to overcome anything!"));
            menuStartingAgeElderly.effectedSkills = new MBList<SkillObject>(); //MBList<SkillObject>
            menuStartingAgeElderly.effectedAttribute = (CharacterAttribute)null; //CharacterAttribute
            menuStartingAgeElderly.focusToAdd = 0;
            menuStartingAgeElderly.skillLevelToAdd = 0;
            menuStartingAgeElderly.attributeLevelToAdd = 0;
            menuStartingAgeElderly.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuStartingAgeElderly.onSelect = new CharacterCreationOnSelect(this.StartingAgeElderlyOnConsequence);//CharacterCreationOnSelect
            menuStartingAgeElderly.onApply = new CharacterCreationApplyFinalEffects(this.StartingAgeElderlyOnApply);//CharacterCreationApplyFinalEffects
            menuStartingAgeElderly.unspentFocusPoint = 8;
            menuStartingAgeElderly.unspentAttributePoint = 4;
            menuStartingAgeElderly.Id = "na_startingageelderly";

            OptionsList.Add(menuStartingAgeYoung);
            OptionsList.Add(menuStartingAgeAdult);
            OptionsList.Add(menuStartingAgeMiddleAged);
            OptionsList.Add(menuStartingAgeElderly);

        }



        protected void StartingAgeOnInit(CharacterCreation characterCreation)
        {
            characterCreation.IsPlayerAlone = true;
            characterCreation.HasSecondaryCharacter = false;
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge((float)this.StartingAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_schooled"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
        }

        protected void StartingAgeYoungOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge((float)this.StartingYoungAdultAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_focus"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SandboxStartingAge = this.StartingYoungAdultAge;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetHeroAge((float)this.StartingYoungAdultAge);
        }

        protected void StartingAgeAdultOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge(this.StartingAdultAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_ready"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SandboxStartingAge = this.StartingAdultAge;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetHeroAge((float)this.StartingAdultAge);
        }

        protected void StartingAgeMiddleAgedOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge(this.StartingMiddleAgedAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_sharp"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SandboxStartingAge = this.StartingMiddleAgedAge;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetHeroAge((float)this.StartingMiddleAgedAge);
        }

        protected void StartingAgeElderlyOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge(this.StartingElderAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_tough"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SandboxStartingAge = this.StartingElderAge;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetHeroAge((float)this.StartingElderAge);
        }

        protected void StartingAgeYoungOnApply(CharacterCreation characterCreation) => this.StartingAge = this.StartingYoungAdultAge;

        protected void StartingAgeAdultOnApply(CharacterCreation characterCreation) => this.StartingAge = this.StartingAdultAge;

        protected void StartingAgeMiddleAgedOnApply(CharacterCreation characterCreation) => this.StartingAge = this.StartingMiddleAgedAge;

        protected void StartingAgeElderlyOnApply(CharacterCreation characterCreation) => this.StartingAge = this.StartingElderAge;


    }
}
