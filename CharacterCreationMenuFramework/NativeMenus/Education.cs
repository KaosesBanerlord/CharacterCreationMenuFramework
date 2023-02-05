using KaosesCommon.Utils;
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
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;

namespace CharacterCreationMenuFramework.NativeMenus
{
    public class Education : ICustomMenu
    {
        public string Id => "native_education";
        public TextObject title => new TextObject("{=rcoueCmk}Adolescence");
        /*        private TextObject _title = new TextObject("{=b4lDDcli}Kaoses Family");
                public TextObject title { get => _title; set => _title = value }*/

        public TextObject description => this._educationIntroductoryText;
        public menuOperationMode OperationMode => menuOperationMode.Add;
        public Operationposition OperationPosition => Operationposition.Default;
        public string OperationmenuId => "native_education";
        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.EducationOnInit);
        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;
        public string textVariable => "";
        public int variableValue => 0;


        public TextObject _educationIntroductoryText = new TextObject("{=!}{EDUCATION_INTRO}");

        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            BuildEducationOptions(characterCreation, characterCreationContent);
        }

        public void RegisterMenu(MenuManager menuManager)
        {
            //menuManager.RegisterMenuObject(this);
        }

        public void RegisterOptions(MenuManager menuManager)
        {
            //throw new NotImplementedException();
        }

        public void BuildEducationOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            CMenuOption menuHerdedSheep = new CMenuOption(new TextObject("{=RKVNvimC}herded the sheep."), new TextObject("{=KfaqPpbK}You went with other fleet-footed youths to take the villages' sheep, goats or cattle to graze in pastures near the village. You were in charge of chasing down stray beasts, and always kept a big stone on hand to be hurled at lurking predators if necessary."));
            menuHerdedSheep.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuHerdedSheep.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuHerdedSheep.focusToAdd = characterCreationContent.FocusToAdd;
            menuHerdedSheep.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuHerdedSheep.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuHerdedSheep.optionCondition = new CharacterCreationOnCondition(this.RuralAdolescenceOnCondition);//CharacterCreationOnCondition
            menuHerdedSheep.onSelect = new CharacterCreationOnSelect(this.RuralAdolescenceHerderOnConsequence);//CharacterCreationOnSelect
            menuHerdedSheep.onApply = new CharacterCreationApplyFinalEffects(this.RuralAdolescenceHerderOnApply);//CharacterCreationApplyFinalEffects
            menuHerdedSheep.Id = "ne_herdedsheep";

            CMenuOption menuVillageSmithy = new CMenuOption(new TextObject("{=bTKiN0hr}worked in the village smithy."), new TextObject("{=y6j1bJTH}You were apprenticed to the local smith. You learned how to heat and forge metal, hammering for hours at a time until your muscles ached."));
            menuVillageSmithy.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.TwoHanded,
                    DefaultSkills.Crafting
                  }; //List<SkillObject>
            menuVillageSmithy.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuVillageSmithy.focusToAdd = characterCreationContent.FocusToAdd;
            menuVillageSmithy.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVillageSmithy.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVillageSmithy.optionCondition = new CharacterCreationOnCondition(this.RuralAdolescenceOnCondition);//CharacterCreationOnCondition
            menuVillageSmithy.onSelect = new CharacterCreationOnSelect(this.RuralAdolescenceSmithyOnConsequence);//CharacterCreationOnSelect
            menuVillageSmithy.onApply = new CharacterCreationApplyFinalEffects(this.RuralAdolescenceSmithyOnApply);//CharacterCreationApplyFinalEffects
            menuVillageSmithy.Id = "ne_workedvillagesmithy";

            CMenuOption menuRepairedProjects = new CMenuOption(new TextObject("{=tI8ZLtoA}repaired projects."), new TextObject("{=6LFj919J}You helped dig wells, rethatch houses, and fix broken plows. You learned about the basics of construction, as well as what it takes to keep a farming community prosperous."));
            menuRepairedProjects.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Crafting,
                    DefaultSkills.Engineering
                  }; //List<SkillObject>
            menuRepairedProjects.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuRepairedProjects.focusToAdd = characterCreationContent.FocusToAdd;
            menuRepairedProjects.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuRepairedProjects.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuRepairedProjects.optionCondition = new CharacterCreationOnCondition(this.RuralAdolescenceOnCondition);//CharacterCreationOnCondition
            menuRepairedProjects.onSelect = new CharacterCreationOnSelect(this.RuralAdolescenceRepairmanOnConsequence);//CharacterCreationOnSelect
            menuRepairedProjects.onApply = new CharacterCreationApplyFinalEffects(this.RuralAdolescenceRepairmanOnApply);//CharacterCreationApplyFinalEffects
            menuRepairedProjects.Id = "ne_repairedprojects";

            CMenuOption menuGathering = new CMenuOption(new TextObject("{=TRwgSLD2}gathered herbs in the wild."), new TextObject("{=9ks4u5cH}You were sent by the village healer up into the hills to look for useful medicinal plants. You learned which herbs healed wounds or brought down a fever, and how to find them."));
            menuGathering.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Medicine,
                    DefaultSkills.Scouting
                  }; //List<SkillObject>
            menuGathering.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuGathering.focusToAdd = characterCreationContent.FocusToAdd;
            menuGathering.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuGathering.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuGathering.optionCondition = new CharacterCreationOnCondition(this.RuralAdolescenceOnCondition);//CharacterCreationOnCondition
            menuGathering.onSelect = new CharacterCreationOnSelect(this.RuralAdolescenceGathererOnConsequence);//CharacterCreationOnSelect
            menuGathering.onApply = new CharacterCreationApplyFinalEffects(this.RuralAdolescenceGathererOnApply);//CharacterCreationApplyFinalEffects
            menuGathering.Id = "ne_gatheredherbswild";

            CMenuOption menuHuntedSmallGame = new CMenuOption(new TextObject("{=T7m7ReTq}hunted small game."), new TextObject("{=RuvSk3QT}You accompanied a local hunter as he went into the wilderness, helping him set up traps and catch small animals."));
            menuHuntedSmallGame.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Bow,
                    DefaultSkills.Tactics
                  }; //List<SkillObject>
            menuHuntedSmallGame.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuHuntedSmallGame.focusToAdd = characterCreationContent.FocusToAdd;
            menuHuntedSmallGame.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuHuntedSmallGame.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuHuntedSmallGame.optionCondition = new CharacterCreationOnCondition(this.RuralAdolescenceOnCondition);//CharacterCreationOnCondition
            menuHuntedSmallGame.onSelect = new CharacterCreationOnSelect(this.RuralAdolescenceHunterOnConsequence);//CharacterCreationOnSelect
            menuHuntedSmallGame.onApply = new CharacterCreationApplyFinalEffects(this.RuralAdolescenceHunterOnApply);//CharacterCreationApplyFinalEffects
            menuHuntedSmallGame.Id = "ne_huntedsmallgame";

            CMenuOption menuWorkedMarket = new CMenuOption(new TextObject("{=qAbMagWq}sold product at the market."), new TextObject("{=DIgsfYfz}You took your family's goods to the nearest town to sell your produce and buy supplies. It was hard work, but you enjoyed the hubbub of the marketplace."));
            menuWorkedMarket.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuWorkedMarket.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuWorkedMarket.focusToAdd = characterCreationContent.FocusToAdd;
            menuWorkedMarket.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuWorkedMarket.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuWorkedMarket.optionCondition = new CharacterCreationOnCondition(this.RuralAdolescenceOnCondition);//CharacterCreationOnCondition
            menuWorkedMarket.onSelect = new CharacterCreationOnSelect(this.RuralAdolescenceHelperOnConsequence);//CharacterCreationOnSelect
            menuWorkedMarket.onApply = new CharacterCreationApplyFinalEffects(this.RuralAdolescenceHelperOnApply);//CharacterCreationApplyFinalEffects
            menuWorkedMarket.Id = "ne_soldproductsatmarket";

            CMenuOption menuTownWatch = new CMenuOption(new TextObject("{=nOfSqRnI}at the town watch's training ground."), new TextObject("{=qnqdEJOv}You watched the town's watch practice shooting and perfect their plans to defend the walls in case of a siege."));
            menuTownWatch.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Crossbow,
                    DefaultSkills.Tactics
                  }; //List<SkillObject>
            menuTownWatch.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuTownWatch.focusToAdd = characterCreationContent.FocusToAdd;
            menuTownWatch.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuTownWatch.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuTownWatch.optionCondition = new CharacterCreationOnCondition(this.UrbanAdolescenceOnCondition);//CharacterCreationOnCondition
            menuTownWatch.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceWatcherOnConsequence);//CharacterCreationOnSelect
            menuTownWatch.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceWatcherOnApply);//CharacterCreationApplyFinalEffects
            menuTownWatch.Id = "ne_townwatchtrainingground";

            CMenuOption menuAlleyGangs = new CMenuOption(new TextObject("{=8a6dnLd2}with the alley gangs."), new TextObject("{=1SUTcF0J}The gang leaders who kept watch over the slums of Calradian cities were always in need of poor youth to run messages and back them up in turf wars, while thrill-seeking merchants' sons and daughters sometimes slummed it in their company as well."));
            menuAlleyGangs.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.OneHanded
                  }; //List<SkillObject>
            menuAlleyGangs.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuAlleyGangs.focusToAdd = characterCreationContent.FocusToAdd;
            menuAlleyGangs.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuAlleyGangs.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuAlleyGangs.optionCondition = new CharacterCreationOnCondition(this.UrbanAdolescenceOnCondition);//CharacterCreationOnCondition
            menuAlleyGangs.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceGangerOnConsequence);//CharacterCreationOnSelect
            menuAlleyGangs.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceGangerOnApply);//CharacterCreationApplyFinalEffects
            menuAlleyGangs.Id = "ne_withalleygangs";

            CMenuOption menuDocksAnBuilding = new CMenuOption(new TextObject("{=7Hv984Sf}at docks and building sites."), new TextObject("{=bhdkegZ4}All towns had their share of projects that were constantly in need of both skilled and unskilled labor. You learned how hoists and scaffolds were constructed, how planks and stones were hewn and fitted, and other skills."));
            menuDocksAnBuilding.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Crafting
                  }; //List<SkillObject>
            menuDocksAnBuilding.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuDocksAnBuilding.focusToAdd = characterCreationContent.FocusToAdd;
            menuDocksAnBuilding.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuDocksAnBuilding.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuDocksAnBuilding.optionCondition = new CharacterCreationOnCondition(this.UrbanAdolescenceOnCondition);//CharacterCreationOnCondition
            menuDocksAnBuilding.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceDockerOnConsequence);//CharacterCreationOnSelect
            menuDocksAnBuilding.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceDockerOnApply);//CharacterCreationApplyFinalEffects
            menuDocksAnBuilding.Id = "ne_dockanbuildingsites";

            CMenuOption menuCaravanserais = new CMenuOption(new TextObject("{=kbcwb5TH}in the markets and caravanserais."), new TextObject("{=lLJh7WAT}You worked in the marketplace, selling trinkets and drinks to busy shoppers."));
            menuCaravanserais.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuCaravanserais.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuCaravanserais.focusToAdd = characterCreationContent.FocusToAdd;
            menuCaravanserais.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuCaravanserais.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuCaravanserais.optionCondition = new CharacterCreationOnCondition(this.UrbanPoorAdolescenceOnCondition);//CharacterCreationOnCondition
            menuCaravanserais.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceMarketerOnConsequence);//CharacterCreationOnSelect
            menuCaravanserais.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceMarketerOnApply);//CharacterCreationApplyFinalEffects
            menuCaravanserais.Id = "ne_marketsandcaravanserais";

            CMenuOption menuMarketsAnCaravanserais = new CMenuOption(new TextObject("{=kbcwb5TH}in the markets and caravanserais."), new TextObject("{=rmMcwSn8}You helped your family handle their business affairs, going down to the marketplace to make purchases and oversee the arrival of caravans."));
            menuMarketsAnCaravanserais.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuMarketsAnCaravanserais.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuMarketsAnCaravanserais.focusToAdd = characterCreationContent.FocusToAdd;
            menuMarketsAnCaravanserais.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuMarketsAnCaravanserais.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuMarketsAnCaravanserais.optionCondition = new CharacterCreationOnCondition(this.UrbanRichAdolescenceOnCondition);//CharacterCreationOnCondition
            menuMarketsAnCaravanserais.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceMarketerOnConsequence);//CharacterCreationOnSelect
            menuMarketsAnCaravanserais.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceMarketerOnApply);//CharacterCreationApplyFinalEffects
            menuMarketsAnCaravanserais.Id = "ne_marketsandcaravanserairich";

            CMenuOption menuReadingAnStudying = new CMenuOption(new TextObject("{=mfRbx5KE}reading and studying."), new TextObject("{=elQnygal}Your family scraped up the money for a rudimentary schooling and you took full advantage, reading voraciously on history, mathematics, and philosophy and discussing what you read with your tutor and classmates."));
            menuReadingAnStudying.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Engineering,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuReadingAnStudying.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuReadingAnStudying.focusToAdd = characterCreationContent.FocusToAdd;
            menuReadingAnStudying.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuReadingAnStudying.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuReadingAnStudying.optionCondition = new CharacterCreationOnCondition(this.UrbanPoorAdolescenceOnCondition);//CharacterCreationOnCondition
            menuReadingAnStudying.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceTutorOnConsequence);//CharacterCreationOnSelect
            menuReadingAnStudying.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceDockerOnApply);//CharacterCreationApplyFinalEffects
            menuReadingAnStudying.Id = "ne_readinganstudying";

            CMenuOption menuWithTutor = new CMenuOption(new TextObject("{=etG87fB7}with your tutor."), new TextObject("{=hXl25avg}Your family arranged for a private tutor and you took full advantage, reading voraciously on history, mathematics, and philosophy and discussing what you read with your tutor and classmates."));
            menuWithTutor.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Engineering,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuWithTutor.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuWithTutor.focusToAdd = characterCreationContent.FocusToAdd;
            menuWithTutor.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuWithTutor.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuWithTutor.optionCondition = new CharacterCreationOnCondition(this.UrbanRichAdolescenceOnCondition);//CharacterCreationOnCondition
            menuWithTutor.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceTutorOnConsequence);//CharacterCreationOnSelect
            menuWithTutor.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceDockerOnApply);//CharacterCreationApplyFinalEffects
            menuWithTutor.Id = "ne_withyourtutor";

            CMenuOption menuCaringHorses = new CMenuOption(new TextObject("{=FKpLEamz}caring for horses."), new TextObject("{=Ghz90npw}Your family owned a few horses at the town stables and you took charge of their care. Many evenings you would take them out beyond the walls and gallup through the fields, racing other youth."));
            menuCaringHorses.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Steward
                  }; //List<SkillObject>
            menuCaringHorses.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuCaringHorses.focusToAdd = characterCreationContent.FocusToAdd;
            menuCaringHorses.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuCaringHorses.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuCaringHorses.optionCondition = new CharacterCreationOnCondition(this.UrbanRichAdolescenceOnCondition);//CharacterCreationOnCondition
            menuCaringHorses.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceHorserOnConsequence);//CharacterCreationOnSelect
            menuCaringHorses.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceDockerOnApply);//CharacterCreationApplyFinalEffects
            menuCaringHorses.Id = "ne_caringforhorses";

            CMenuOption menuWorkingStables = new CMenuOption(new TextObject("{=vH7GtuuK}working at the stables."), new TextObject("{=csUq1RCC}You were employed as a hired hand at the town's stables. The overseers recognized that you had a knack for horses, and you were allowed to exercise them and sometimes even break in new steeds."));
            menuWorkingStables.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Steward
                  }; //List<SkillObject>
            menuWorkingStables.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuWorkingStables.focusToAdd = characterCreationContent.FocusToAdd;
            menuWorkingStables.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuWorkingStables.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuWorkingStables.optionCondition = new CharacterCreationOnCondition(this.UrbanPoorAdolescenceOnCondition);//CharacterCreationOnCondition
            menuWorkingStables.onSelect = new CharacterCreationOnSelect(this.UrbanAdolescenceHorserOnConsequence);//CharacterCreationOnSelect
            menuWorkingStables.onApply = new CharacterCreationApplyFinalEffects(this.UrbanAdolescenceDockerOnApply);//CharacterCreationApplyFinalEffects
            menuWorkingStables.Id = "ne_workingatstables";

            OptionsList.Add(menuHerdedSheep);
            OptionsList.Add(menuVillageSmithy);
            OptionsList.Add(menuRepairedProjects);
            OptionsList.Add(menuGathering);
            OptionsList.Add(menuHuntedSmallGame);
            OptionsList.Add(menuWorkedMarket);
            OptionsList.Add(menuTownWatch);
            OptionsList.Add(menuAlleyGangs);
            OptionsList.Add(menuDocksAnBuilding);
            OptionsList.Add(menuCaravanserais);
            OptionsList.Add(menuMarketsAnCaravanserais);
            OptionsList.Add(menuReadingAnStudying);
            OptionsList.Add(menuWithTutor);
            OptionsList.Add(menuCaringHorses);
            OptionsList.Add(menuWorkingStables);

        }


        public void EducationOnInit(CharacterCreation characterCreation)
        {
            characterCreation.IsPlayerAlone = true;
            characterCreation.HasSecondaryCharacter = false;
            characterCreation.ClearFaceGenPrefab();
            TextObject textObject1 = new TextObject("{=WYvnWcXQ}Like all village children you helped out in the fields. You also...");
            TextObject textObject2 = new TextObject("{=DsCkf6Pb}Growing up, you spent most of your time...");
            this._educationIntroductoryText.SetTextVariable("EDUCATION_INTRO", this.RuralType() ? textObject1 : textObject2);
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge((float)CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.EducationAge));
            string outfit = "player_char_creation_education_age_" + CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId + "_" + (object)CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedParentType + (Hero.MainHero.IsFemale ? "_f" : "_m");
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerOutfit(characterCreation, outfit);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_schooled"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ClearMountEntity(characterCreation);
        }


        public bool RuralType() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Hunter || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Bard || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Herder || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Vagabond || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Healer || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Artisan;

        public bool RichParents() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant;

        public bool RuralChildhoodOnCondition() => this.RuralType();

        public bool UrbanChildhoodOnCondition() => !this.RuralType();

        public bool RuralAdolescenceOnCondition() => this.RuralType();

        public bool UrbanAdolescenceOnCondition() => !this.RuralType();

        public bool UrbanRichAdolescenceOnCondition() => !this.RuralType() && this.RichParents();

        public bool UrbanPoorAdolescenceOnCondition() => !this.RuralType() && !this.RichParents();

        public void RuralAdolescenceHerderOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_streets"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "carry_bostaff_rogue1", true);
        }

        public void RuralAdolescenceSmithyOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_militia"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "peasant_hammer_1_t1", true);
        }

        public void RuralAdolescenceRepairmanOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_grit"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "carry_hammer", true);
        }

        public void RuralAdolescenceGathererOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_peddlers"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "_to_carry_bd_basket_a", true);
        }

        public void RuralAdolescenceHunterOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_sharp"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "composite_bow", true);
        }

        public void RuralAdolescenceHelperOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_manners"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "", true);
        }

        public void UrbanAdolescenceWatcherOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_fox"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "", true);
        }

        public void UrbanAdolescenceMarketerOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_manners"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "", true);
        }

        public void UrbanAdolescencePreacherOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_leader"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "", true);
        }

        public void UrbanAdolescenceGangerOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_athlete"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "", true);
        }

        public void UrbanAdolescenceDockerOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_peddlers"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "_to_carry_bd_basket_a", true);
        }

        public void UrbanAdolescenceHorserOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_peddlers_2"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "_to_carry_bd_fabric_c", true);
        }

        public void UrbanAdolescenceTutorOnConsequence(CharacterCreation characterCreation)
        {
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_book"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPropsAndClothing(characterCreation, false, "character_creation_notebook", false);
        }

        public void RuralAdolescenceHerderOnApply(CharacterCreation characterCreation)
        {
        }

        public void RuralAdolescenceSmithyOnApply(CharacterCreation characterCreation)
        {
        }

        public void RuralAdolescenceRepairmanOnApply(CharacterCreation characterCreation)
        {
        }

        public void RuralAdolescenceGathererOnApply(CharacterCreation characterCreation)
        {
        }

        public void RuralAdolescenceHunterOnApply(CharacterCreation characterCreation)
        {
        }

        public void RuralAdolescenceHelperOnApply(CharacterCreation characterCreation)
        {
        }

        public void UrbanAdolescenceWatcherOnApply(CharacterCreation characterCreation)
        {
        }

        public void UrbanAdolescenceMarketerOnApply(CharacterCreation characterCreation)
        {
        }

        public void UrbanAdolescencePreacherOnApply(CharacterCreation characterCreation)
        {
        }

        public void UrbanAdolescenceGangerOnApply(CharacterCreation characterCreation)
        {
        }

        public void UrbanAdolescenceDockerOnApply(CharacterCreation characterCreation)
        {
        }

        public void UrbanAdolescenceTutorOnApply(CharacterCreation characterCreation)
        {
        }

    }
}
