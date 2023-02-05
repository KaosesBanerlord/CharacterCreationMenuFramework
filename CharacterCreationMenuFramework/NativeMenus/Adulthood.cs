using CharacterCreationMenuFramework.Interfaces;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.Objects;
using CharacterCreationMenuFramework.StartObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;

namespace CharacterCreationMenuFramework.NativeMenus
{
    public class Adulthood : ICustomMenu
    {
        public string Id => "native_adult";
        public TextObject title => new TextObject("{=MafIe9yI}Young Adulthood");
        /*        private TextObject _title = new TextObject("{=b4lDDcli}Kaoses Family");
                public TextObject title { get => _title; set => _title = value }*/
        public TextObject description => new TextObject("{=4WYY0X59}Before you set out for a life of adventure, your biggest achievement was...");
        public menuOperationMode OperationMode => menuOperationMode.Add;
        public Operationposition OperationPosition => Operationposition.Default;
        public string OperationmenuId => "native_adult";
        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.AccomplishmentOnInit);
        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;
        public string textVariable => "EXP_VALUE";
        //public int variableValue => Factory.KaosesCharacterCreation.SkillLevelToAdd;
        public int variableValue => 10;

        protected KaosesStoryModeCharacterCreationContent _characterCreationContent;


        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            _characterCreationContent = characterCreationContent;
            //MBTextManager.SetTextVariable("EXP_VALUE", this.SkillLevelToAdd);
            BuildAdultHoodOptions(characterCreation, characterCreationContent);
        }

        public void RegisterMenu(MenuManager menuManager)
        {
            //menuManager.RegisterMenuObject(this);
        }

        public void RegisterOptions(MenuManager menuManager)
        {
            //throw new NotImplementedException();
        }

        public void BuildAdultHoodOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {

            CMenuOption menuDefeatedAnEnemy = new CMenuOption(new TextObject("{=8bwpVpgy}you defeated an enemy in battle."), new TextObject("{=1IEroJKs}Not everyone who musters for the levy marches to war, and not everyone who goes on campaign sees action. You did both, and you also took down an enemy warrior in direct one-to-one combat, in the full view of your comrades."));
            menuDefeatedAnEnemy.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.OneHanded,
                    DefaultSkills.TwoHanded
                  }; //List<SkillObject>
            menuDefeatedAnEnemy.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuDefeatedAnEnemy.focusToAdd = characterCreationContent.FocusToAdd;
            menuDefeatedAnEnemy.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuDefeatedAnEnemy.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuDefeatedAnEnemy.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuDefeatedAnEnemy.onSelect = new CharacterCreationOnSelect(this.AccomplishmentDefeatedEnemyOnConsequence);//CharacterCreationOnSelect
            menuDefeatedAnEnemy.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentDefeatedEnemyOnApply);//CharacterCreationApplyFinalEffects
            menuDefeatedAnEnemy.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Valor
                  };
            menuDefeatedAnEnemy.traitLevelToAdd = 1;
            menuDefeatedAnEnemy.renownToAdd = 20;
            menuDefeatedAnEnemy.Id = "na_defeatedenemyinbattle";

            CMenuOption menuManHunt = new CMenuOption(new TextObject("{=mP3uFbcq}you led a successful manhunt."), new TextObject("{=4f5xwzX0}When your community needed to organize a posse to pursue horse thieves, you were the obvious choice. You hunted down the raiders, surrounded them and forced their surrender, and took back your stolen property."));
            menuManHunt.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Tactics,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuManHunt.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuManHunt.focusToAdd = characterCreationContent.FocusToAdd;
            menuManHunt.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuManHunt.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuManHunt.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentPosseOnConditions);//CharacterCreationOnCondition
            menuManHunt.onSelect = new CharacterCreationOnSelect(this.AccomplishmentExpeditionOnConsequence);//CharacterCreationOnSelect
            menuManHunt.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentExpeditionOnApply);//CharacterCreationApplyFinalEffects
            menuManHunt.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Calculating
                  };
            menuManHunt.traitLevelToAdd = 1;
            menuManHunt.renownToAdd = 10;
            menuManHunt.Id = "na_ledsuccessfulmanhunt";

            CMenuOption menuLedCaravan = new CMenuOption(new TextObject("{=wfbtS71d}you led a caravan."), new TextObject("{=joRHKCkm}Your family needed someone trustworthy to take a caravan to a neighboring town. You organized supplies, ensured a constant watch to keep away bandits, and brought it safely to its destination."));
            menuLedCaravan.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Tactics,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuLedCaravan.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuLedCaravan.focusToAdd = characterCreationContent.FocusToAdd;
            menuLedCaravan.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuLedCaravan.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuLedCaravan.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentMerchantOnCondition);//CharacterCreationOnCondition
            menuLedCaravan.onSelect = new CharacterCreationOnSelect(this.AccomplishmentMerchantOnConsequence);//CharacterCreationOnSelect
            menuLedCaravan.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentExpeditionOnApply);//CharacterCreationApplyFinalEffects
            menuLedCaravan.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Calculating
                  };
            menuLedCaravan.traitLevelToAdd = 1;
            menuLedCaravan.renownToAdd = 10;
            menuLedCaravan.Id = "na_ledacaravan";

            CMenuOption menuSavedVillageFromFlood = new CMenuOption(new TextObject("{=x1HTX5hq}you saved your village from a flood."), new TextObject("{=bWlmGDf3}When a sudden storm caused the local stream to rise suddenly, your neighbors needed quick-thinking leadership. You provided it, directing them to build levees to save their homes."));
            menuSavedVillageFromFlood.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Tactics,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuSavedVillageFromFlood.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuSavedVillageFromFlood.focusToAdd = characterCreationContent.FocusToAdd;
            menuSavedVillageFromFlood.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSavedVillageFromFlood.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSavedVillageFromFlood.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentSavedVillageOnCondition);//CharacterCreationOnCondition
            menuSavedVillageFromFlood.onSelect = new CharacterCreationOnSelect(this.AccomplishmentSavedVillageOnConsequence);//CharacterCreationOnSelect
            menuSavedVillageFromFlood.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentExpeditionOnApply);//CharacterCreationApplyFinalEffects
            menuSavedVillageFromFlood.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Calculating
                  };
            menuSavedVillageFromFlood.traitLevelToAdd = 1;
            menuSavedVillageFromFlood.renownToAdd = 10;
            menuSavedVillageFromFlood.Id = "na_savedvillagefromflood";

            CMenuOption menuSavedCityFromFire = new CMenuOption(new TextObject("{=s8PNllPN}you saved your city quarter from a fire."), new TextObject("{=ZAGR6PYc}When a sudden blaze broke out in a back alley, your neighbors needed quick-thinking leadership and you provided it. You organized a bucket line to the nearest well, putting the fire out before any homes were lost."));
            menuSavedCityFromFire.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Tactics,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuSavedCityFromFire.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuSavedCityFromFire.focusToAdd = characterCreationContent.FocusToAdd;
            menuSavedCityFromFire.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSavedCityFromFire.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSavedCityFromFire.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentSavedStreetOnCondition);//CharacterCreationOnCondition
            menuSavedCityFromFire.onSelect = new CharacterCreationOnSelect(this.AccomplishmentSavedStreetOnConsequence);//CharacterCreationOnSelect
            menuSavedCityFromFire.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentExpeditionOnApply);//CharacterCreationApplyFinalEffects
            menuSavedCityFromFire.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Calculating
                  };
            menuSavedCityFromFire.traitLevelToAdd = 1;
            menuSavedCityFromFire.renownToAdd = 10;
            menuSavedCityFromFire.Id = "na_savedcityfromfire";

            CMenuOption menuInvestedInWorkshop = new CMenuOption(new TextObject("{=xORjDTal}you invested some money in a workshop."), new TextObject("{=PyVqDLBu}Your parents didn't give you much money, but they did leave just enough for you to secure a loan against a larger amount to build a small workshop. You paid back what you borrowed, and sold your enterprise for a profit."));
            menuInvestedInWorkshop.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Crafting
                  }; //List<SkillObject>
            menuInvestedInWorkshop.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuInvestedInWorkshop.focusToAdd = characterCreationContent.FocusToAdd;
            menuInvestedInWorkshop.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuInvestedInWorkshop.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuInvestedInWorkshop.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentUrbanOnCondition);//CharacterCreationOnCondition
            menuInvestedInWorkshop.onSelect = new CharacterCreationOnSelect(this.AccomplishmentWorkshopOnConsequence);//CharacterCreationOnSelect
            menuInvestedInWorkshop.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentWorkshopOnApply);//CharacterCreationApplyFinalEffects
            menuInvestedInWorkshop.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Calculating
                  };
            menuInvestedInWorkshop.traitLevelToAdd = 1;
            menuInvestedInWorkshop.renownToAdd = 10;
            menuInvestedInWorkshop.Id = "na_investedmoneyworkshop";

            CMenuOption menuInvestedInLand = new CMenuOption(new TextObject("{=xKXcqRJI}you invested some money in land."), new TextObject("{=cbF9jdQo}Your parents didn't give you much money, but they did leave just enough for you to purchase a plot of unused land at the edge of the village. You cleared away rocks and dug an irrigation ditch, raised a few seasons of crops, than sold it for a considerable profit."));
            menuInvestedInLand.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Crafting
                  }; //List<SkillObject>
            menuInvestedInLand.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuInvestedInLand.focusToAdd = characterCreationContent.FocusToAdd;
            menuInvestedInLand.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuInvestedInLand.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuInvestedInLand.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentRuralOnCondition);//CharacterCreationOnCondition
            menuInvestedInLand.onSelect = new CharacterCreationOnSelect(this.AccomplishmentWorkshopOnConsequence);//CharacterCreationOnSelect
            menuInvestedInLand.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentWorkshopOnApply);//CharacterCreationApplyFinalEffects
            menuInvestedInLand.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Calculating
                  };
            menuInvestedInLand.traitLevelToAdd = 1;
            menuInvestedInLand.renownToAdd = 10;
            menuInvestedInLand.Id = "na_investedmoneyland";

            CMenuOption menuHuntedDangerousAnimal = new CMenuOption(new TextObject("{=TbNRtUjb}you hunted a dangerous animal."), new TextObject("{=I3PcdaaL}Wolves, bears are a constant menace to the flocks of northern Calradia, while hyenas and leopards trouble the south. You went with a group of your fellow villagers and fired the missile that brought down the beast."));
            menuHuntedDangerousAnimal.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Polearm,
                    DefaultSkills.Crossbow
                  }; //List<SkillObject>
            menuHuntedDangerousAnimal.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuHuntedDangerousAnimal.focusToAdd = characterCreationContent.FocusToAdd;
            menuHuntedDangerousAnimal.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuHuntedDangerousAnimal.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuHuntedDangerousAnimal.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentRuralOnCondition);//CharacterCreationOnCondition
            menuHuntedDangerousAnimal.onSelect = new CharacterCreationOnSelect(this.AccomplishmentSiegeHunterOnConsequence);//CharacterCreationOnSelect
            menuHuntedDangerousAnimal.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentSiegeHunterOnApply);//CharacterCreationApplyFinalEffects
            menuHuntedDangerousAnimal.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Valor
                  };
            menuHuntedDangerousAnimal.traitLevelToAdd = 1;
            menuHuntedDangerousAnimal.renownToAdd = 5;
            menuHuntedDangerousAnimal.Id = "na_huntedadangerousanimal";

            CMenuOption menuSurvivedSiege = new CMenuOption(new TextObject("{=WbHfGCbd}you survived a siege."), new TextObject("{=FhZPjhli}Your hometown was briefly placed under siege, and you were called to defend the walls. Everyone did their part to repulse the enemy assault, and everyone is justly proud of what they endured."));
            menuSurvivedSiege.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Bow,
                    DefaultSkills.Crossbow
                  }; //List<SkillObject>
            menuSurvivedSiege.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuSurvivedSiege.focusToAdd = characterCreationContent.FocusToAdd;
            menuSurvivedSiege.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSurvivedSiege.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSurvivedSiege.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentUrbanOnCondition);//CharacterCreationOnCondition
            menuSurvivedSiege.onSelect = new CharacterCreationOnSelect(this.AccomplishmentSiegeHunterOnConsequence);//CharacterCreationOnSelect
            menuSurvivedSiege.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentSiegeHunterOnApply);//CharacterCreationApplyFinalEffects
            menuSurvivedSiege.renownToAdd = 5;
            menuSurvivedSiege.Id = "na_survivedsiege";

            CMenuOption menuFamousEscapade = new CMenuOption(new TextObject("{=kNXet6Um}you had a famous escapade in town."), new TextObject("{=DjeAJtix}Maybe it was a love affair, or maybe you cheated at dice, or maybe you just chose your words poorly when drinking with a dangerous crowd. Anyway, on one of your trips into town you got into the kind of trouble from which only a quick tongue or quick feet get you out alive."));
            menuFamousEscapade.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Roguery
                  }; //List<SkillObject>
            menuFamousEscapade.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuFamousEscapade.focusToAdd = characterCreationContent.FocusToAdd;
            menuFamousEscapade.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuFamousEscapade.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuFamousEscapade.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentRuralOnCondition);//CharacterCreationOnCondition
            menuFamousEscapade.onSelect = new CharacterCreationOnSelect(this.AccomplishmentEscapadeOnConsequence);//CharacterCreationOnSelect
            menuFamousEscapade.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentEscapadeOnApply);//CharacterCreationApplyFinalEffects
            menuFamousEscapade.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Valor
                  };
            menuFamousEscapade.traitLevelToAdd = 1;
            menuFamousEscapade.renownToAdd = 5;
            menuFamousEscapade.Id = "na_famousescapadeintown";

            CMenuOption menuFamousEscapade2 = new CMenuOption(new TextObject("{=qlOuiKXj}you had a famous escapade."), new TextObject("{=lD5Ob3R4}Maybe it was a love affair, or maybe you cheated at dice, or maybe you just chose your words poorly when drinking with a dangerous crowd. Anyway, you got into the kind of trouble from which only a quick tongue or quick feet get you out alive."));
            menuFamousEscapade2.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Roguery
                  }; //List<SkillObject>
            menuFamousEscapade2.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuFamousEscapade2.focusToAdd = characterCreationContent.FocusToAdd;
            menuFamousEscapade2.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuFamousEscapade2.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuFamousEscapade2.optionCondition = new CharacterCreationOnCondition(this.AccomplishmentUrbanOnCondition);//CharacterCreationOnCondition
            menuFamousEscapade2.onSelect = new CharacterCreationOnSelect(this.AccomplishmentEscapadeOnConsequence);//CharacterCreationOnSelect
            menuFamousEscapade2.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentEscapadeOnApply);//CharacterCreationApplyFinalEffects
            menuFamousEscapade2.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Valor
                  };
            menuFamousEscapade2.traitLevelToAdd = 1;
            menuFamousEscapade2.renownToAdd = 5;
            menuFamousEscapade2.Id = "na_famousescapadeintownother";

            CMenuOption menutreatedPeopleWell = new CMenuOption(new TextObject("{=Yqm0Dics}you treated people well."), new TextObject("{=dDmcqTzb}Yours wasn't the kind of reputation that local legends are made of, but it was the kind that wins you respect among those around you. You were consistently fair and honest in your business dealings and helpful to those in trouble. In doing so, you got a sense of what made people tick."));
            menutreatedPeopleWell.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Charm,
                    DefaultSkills.Steward
                  }; //List<SkillObject>
            menutreatedPeopleWell.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menutreatedPeopleWell.focusToAdd = characterCreationContent.FocusToAdd;
            menutreatedPeopleWell.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menutreatedPeopleWell.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menutreatedPeopleWell.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menutreatedPeopleWell.onSelect = new CharacterCreationOnSelect(this.AccomplishmentTreaterOnConsequence);//CharacterCreationOnSelect
            menutreatedPeopleWell.onApply = new CharacterCreationApplyFinalEffects(this.AccomplishmentTreaterOnApply);//CharacterCreationApplyFinalEffects
            menutreatedPeopleWell.effectedTraits = new List<TraitObject>()
                  {
                    DefaultTraits.Mercy,
                    DefaultTraits.Generosity,
                    DefaultTraits.Honor
                  };
            menutreatedPeopleWell.traitLevelToAdd = 1;
            menutreatedPeopleWell.renownToAdd = 5;
            menutreatedPeopleWell.Id = "na_treatedpeoplewell";





            OptionsList.Add(menuDefeatedAnEnemy);
            OptionsList.Add(menuManHunt);
            OptionsList.Add(menuLedCaravan);
            OptionsList.Add(menuSavedVillageFromFlood);
            OptionsList.Add(menuSavedCityFromFire);
            OptionsList.Add(menuInvestedInWorkshop);
            OptionsList.Add(menuInvestedInLand);
            OptionsList.Add(menuHuntedDangerousAnimal);
            OptionsList.Add(menuSurvivedSiege);
            OptionsList.Add(menuFamousEscapade);
            OptionsList.Add(menuFamousEscapade2);
            OptionsList.Add(menutreatedPeopleWell);
        }




        public void AccomplishmentOnInit(CharacterCreation characterCreation)
        {
            characterCreation.IsPlayerAlone = true;
            characterCreation.HasSecondaryCharacter = false;
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(this.ChangePlayerFaceWithAge((float)CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.AccomplishmentAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_schooled"
      });
            _characterCreationContent.RefreshPlayerAppearance(characterCreation);
        }

        public void AccomplishmentDefeatedEnemyOnApply(CharacterCreation characterCreation)
        {
        }

        public void AccomplishmentExpeditionOnApply(CharacterCreation characterCreation)
        {
        }

        public bool AccomplishmentRuralOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RuralType();

        public bool AccomplishmentMerchantOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant;

        public bool AccomplishmentPosseOnConditions() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Herder || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Mercenary;

        public bool AccomplishmentSavedVillageOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RuralType() && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType != KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType != KaosesStoryModeCharacterCreationContent.OccupationTypes.Herder;

        public bool AccomplishmentSavedStreetOnCondition() => !CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RuralType() && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType != KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType != KaosesStoryModeCharacterCreationContent.OccupationTypes.Mercenary;

        public bool AccomplishmentUrbanOnCondition() => !CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RuralType();

        public void AccomplishmentWorkshopOnApply(CharacterCreation characterCreation)
        {
        }

        public void AccomplishmentSiegeHunterOnApply(CharacterCreation characterCreation)
        {
        }

        public void AccomplishmentEscapadeOnApply(CharacterCreation characterCreation)
        {
        }

        public void AccomplishmentTreaterOnApply(CharacterCreation characterCreation)
        {
        }

        public void AccomplishmentDefeatedEnemyOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_athlete"
    });

        public void AccomplishmentExpeditionOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_gracious"
    });

        public void AccomplishmentMerchantOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_ready"
    });

        public void AccomplishmentSavedVillageOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_vibrant"
    });

        public void AccomplishmentSavedStreetOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_vibrant"
    });

        public void AccomplishmentWorkshopOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_decisive"
    });

        public void AccomplishmentSiegeHunterOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_tough"
    });

        public void AccomplishmentEscapadeOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_clever"
    });

        public void AccomplishmentTreaterOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_manners"
    });

        public List<FaceGenChar> ChangePlayerFaceWithAge(float age, string actionName = "act_childhood_schooled")
        {
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, age);
            faceGenCharList.Add(new FaceGenChar(originalBodyProperties, CharacterObject.PlayerCharacter.Race, new Equipment(), CharacterObject.PlayerCharacter.IsFemale, actionName));
            return faceGenCharList;
        }



    }
}
