using CharacterCreationMenuFramework.Interfaces;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.StartObj;
using static CharacterCreationMenuFramework.Enums;
using StoryMode.StoryModeObjects;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using CharacterCreationMenuFramework.Objects;

namespace CharacterCreationMenuFramework.NativeMenus
{
    public class Background : ICustomMenu
    {
        public string Id => "native_background";
        public TextObject title => new TextObject("{=peNBA0WW}Story Background");
        /*        private TextObject _title = new TextObject("{=b4lDDcli}Kaoses Family");
                public TextObject title { get => _title; set => _title = value }*/

        public TextObject description => new TextObject("{=jg3T5AyE}Like many families in Calradia, your life was upended by war. Your home was ravaged by the passage of army after army. Eventually, you sold your property and set off with your father, mother, brother, and your two younger siblings to a new town you'd heard was safer. But you did not make it. Along the way, the inn at which you were staying was attacked by raiders. Your parents were slain and your two youngest siblings seized, but you and your brother survived because...");
        public menuOperationMode OperationMode => menuOperationMode.Add;
        public Operationposition OperationPosition => Operationposition.Default;
        public string OperationmenuId => "native_background";
        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.EscapeOnInit);
        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;

        public string textVariable => "EXP_VALUE";
        //public int variableValue => Factory.KaosesCharacterCreation.SkillLevelToAdd;
        public int variableValue => 10;

        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            //MBTextManager.SetTextVariable("EXP_VALUE", this.SkillLevelToAdd);
            BuildBackgroundOptions(characterCreation, characterCreationContent);
        }

        public void RegisterMenu(MenuManager menuManager)
        {
            //menuManager.RegisterMenuObject(this);
        }

        public void RegisterOptions(MenuManager menuManager)
        {
            //throw new NotImplementedException();
        }

        public void BuildBackgroundOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            CMenuOption menuSubdedRaider = new CMenuOption(new TextObject("{=6vCHovVH}you subdued a raider."), new TextObject("{=CvBoRaFv}You were able to grab a knife in the confusion of the attack. You stabbed a raider blocking your way."));
            menuSubdedRaider.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.OneHanded,
                    DefaultSkills.Athletics
                  }; //List<SkillObject>
            menuSubdedRaider.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuSubdedRaider.focusToAdd = characterCreationContent.FocusToAdd;
            menuSubdedRaider.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSubdedRaider.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSubdedRaider.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuSubdedRaider.onSelect = new CharacterCreationOnSelect(this.EscapeSubdueRaiderOnConsequence);//CharacterCreationOnSelect
            menuSubdedRaider.onApply = new CharacterCreationApplyFinalEffects(this.EscapeSubdueRaiderOnApply);//CharacterCreationApplyFinalEffects
            menuSubdedRaider.Id = "nb_subdedraider";

            CMenuOption menuDroveOffWithArrows = new CMenuOption(new TextObject("{=2XhW49TX}you drove them off with arrows."), new TextObject("{=ccf67J3J}You grabbed a bow and sent a few arrows the raiders' way. They took cover, giving you the opportunity to flee with your brother."));
            menuDroveOffWithArrows.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Bow,
                    DefaultSkills.Tactics
                  }; //List<SkillObject>
            menuDroveOffWithArrows.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuDroveOffWithArrows.focusToAdd = characterCreationContent.FocusToAdd;
            menuDroveOffWithArrows.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuDroveOffWithArrows.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuDroveOffWithArrows.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuDroveOffWithArrows.onSelect = new CharacterCreationOnSelect(this.EscapeDrawArrowsOnConsequence);//CharacterCreationOnSelect
            menuDroveOffWithArrows.onApply = new CharacterCreationApplyFinalEffects(this.EscapeDrawArrowsOnApply);//CharacterCreationApplyFinalEffects
            menuDroveOffWithArrows.Id = "nb_drovethemoffwitharrows";

            CMenuOption menuRodeOffFastHorse = new CMenuOption(new TextObject("{=gOI8lKcl}you rode off on a fast horse."), new TextObject("{=cepWNzEA}Jumping on the two remaining horses in the inn's burning stable, you and your brother broke out of the encircling raiders and rode off."));
            menuRodeOffFastHorse.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Scouting
                  }; //List<SkillObject>
            menuRodeOffFastHorse.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuRodeOffFastHorse.focusToAdd = characterCreationContent.FocusToAdd;
            menuRodeOffFastHorse.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuRodeOffFastHorse.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuRodeOffFastHorse.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuRodeOffFastHorse.onSelect = new CharacterCreationOnSelect(this.EscapeFastHorseOnConsequence);//CharacterCreationOnSelect
            menuRodeOffFastHorse.onApply = new CharacterCreationApplyFinalEffects(this.EscapeFastHorseOnApply);//CharacterCreationApplyFinalEffects
            menuRodeOffFastHorse.Id = "nb_rodeoffonfasthorse";

            CMenuOption menuTrickedRaiders = new CMenuOption(new TextObject("{=EdUppdLZ}you tricked the raiders."), new TextObject("{=ZqOvtLBM}In the confusion of the attack you shouted that someone had found treasure in the back room. You then made your way out of the undefended entrance with your brother."));
            menuTrickedRaiders.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.Tactics
                  }; //List<SkillObject>
            menuTrickedRaiders.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuTrickedRaiders.focusToAdd = characterCreationContent.FocusToAdd;
            menuTrickedRaiders.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuTrickedRaiders.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuTrickedRaiders.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuTrickedRaiders.onSelect = new CharacterCreationOnSelect(this.EscapeRoadOffWithBrotherOnConsequence);//CharacterCreationOnSelect
            menuTrickedRaiders.onApply = new CharacterCreationApplyFinalEffects(this.EscapeRoadOffWithBrotherOnApply);//CharacterCreationApplyFinalEffects
            menuTrickedRaiders.Id = "nb_trickedtheraiders";

            CMenuOption menuOrganisedTravellersBreakout = new CMenuOption(new TextObject("{=qhAhPWdp}you organized the travelers to break out."), new TextObject("{=Lmfi0cYk}You encouraged the few travellers in the inn to break out in a coordinated fashion. Raiders killed or captured most but you and your brother were able to escape."));
            menuOrganisedTravellersBreakout.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Leadership,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuOrganisedTravellersBreakout.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuOrganisedTravellersBreakout.focusToAdd = characterCreationContent.FocusToAdd;
            menuOrganisedTravellersBreakout.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuOrganisedTravellersBreakout.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuOrganisedTravellersBreakout.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuOrganisedTravellersBreakout.onSelect = new CharacterCreationOnSelect(this.EscapeOrganizeTravellersOnConsequence);//CharacterCreationOnSelect
            menuOrganisedTravellersBreakout.onApply = new CharacterCreationApplyFinalEffects(this.EscapeOrganizeTravellersOnApply);//CharacterCreationApplyFinalEffects
            menuOrganisedTravellersBreakout.Id = "nb_organisedtravellersbreakout";


            OptionsList.Add(menuSubdedRaider);
            OptionsList.Add(menuDroveOffWithArrows);
            OptionsList.Add(menuRodeOffFastHorse);
            OptionsList.Add(menuTrickedRaiders);
            OptionsList.Add(menuOrganisedTravellersBreakout);


        }






        public void EscapeOnInit(CharacterCreation characterCreation)
        {
            characterCreation.IsPlayerAlone = false;
            characterCreation.HasSecondaryCharacter = true;
            characterCreation.ClearFaceGenPrefab();
            this.ClearCharacters(characterCreation);
            this.ClearMountEntity(characterCreation);
            Hero elderBrother = StoryModeHeroes.ElderBrother;
            List<FaceGenChar> newChars = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, 23f);
            this.CreateSibling(StoryModeHeroes.LittleBrother);
            this.CreateSibling(StoryModeHeroes.LittleSister);
            BodyProperties bodyProperties = BodyProperties.GetRandomBodyProperties(elderBrother.CharacterObject.Race, elderBrother.IsFemale, CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.MotherFacegenCharacter.BodyProperties, CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.FatherFacegenCharacter.BodyProperties, 1, Hero.MainHero.Mother.CharacterObject.GetDefaultFaceSeed(1), Hero.MainHero.Father.HairTags, Hero.MainHero.Father.BeardTags, Hero.MainHero.Father.TattooTags);
            bodyProperties = new BodyProperties(new DynamicBodyProperties(elderBrother.Age, 0.5f, 0.5f), bodyProperties.StaticProperties);
            elderBrother.ModifyPlayersFamilyAppearance(bodyProperties.StaticProperties);
            elderBrother.Weight = bodyProperties.Weight;
            elderBrother.Build = bodyProperties.Build;
            newChars.Add(new FaceGenChar(originalBodyProperties, CharacterObject.PlayerCharacter.Race, new Equipment(), CharacterObject.PlayerCharacter.IsFemale, "act_childhood_schooled"));
            newChars.Add(new FaceGenChar(elderBrother.BodyProperties, CharacterObject.PlayerCharacter.Race, new Equipment(), elderBrother.CharacterObject.IsFemale, "act_childhood_schooled"));
            characterCreation.ChangeFaceGenChars(newChars);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_schooled",
        "act_childhood_schooled"
      });
            this.ChangeStoryStageEquipments(characterCreation);
            List<FaceGenMount> faceGenMountList1 = new List<FaceGenMount>();
            EquipmentElement equipmentElement;
            if (CharacterObject.PlayerCharacter.HasMount())
            {
                equipmentElement = CharacterObject.PlayerCharacter.Equipment[EquipmentIndex.ArmorItemEndSlot];
                ItemObject mountItem = equipmentElement.Item;
                List<FaceGenMount> faceGenMountList2 = faceGenMountList1;
                MountCreationKey randomMountKey = MountCreationKey.GetRandomMountKey(mountItem, CharacterObject.PlayerCharacter.GetMountKeySeed());
                equipmentElement = CharacterObject.PlayerCharacter.Equipment[EquipmentIndex.ArmorItemEndSlot];
                ItemObject horseItem = equipmentElement.Item;
                equipmentElement = CharacterObject.PlayerCharacter.Equipment[EquipmentIndex.HorseHarness];
                ItemObject harnessItem = equipmentElement.Item;
                FaceGenMount faceGenMount = new FaceGenMount(randomMountKey, horseItem, harnessItem);
                faceGenMountList2.Add(faceGenMount);
            }
            if (!elderBrother.CharacterObject.HasMount())
                return;
            equipmentElement = elderBrother.CharacterObject.Equipment[EquipmentIndex.ArmorItemEndSlot];
            ItemObject mountItem1 = equipmentElement.Item;
            List<FaceGenMount> faceGenMountList3 = faceGenMountList1;
            MountCreationKey randomMountKey1 = MountCreationKey.GetRandomMountKey(mountItem1, elderBrother.CharacterObject.GetMountKeySeed());
            equipmentElement = elderBrother.CharacterObject.Equipment[EquipmentIndex.ArmorItemEndSlot];
            ItemObject horseItem1 = equipmentElement.Item;
            equipmentElement = elderBrother.CharacterObject.Equipment[EquipmentIndex.HorseHarness];
            ItemObject harnessItem1 = equipmentElement.Item;
            FaceGenMount faceGenMount1 = new FaceGenMount(randomMountKey1, horseItem1, harnessItem1);
            faceGenMountList3.Add(faceGenMount1);
        }


        public void ChangeStoryStageEquipments(CharacterCreation characterCreation) => characterCreation.ChangeCharactersEquipment(new List<Equipment>()
    {
      CharacterObject.PlayerCharacter.Equipment,
      StoryModeHeroes.ElderBrother.CharacterObject.Equipment
    });

        public void EscapeSubdueRaiderOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_fierce",
      "act_childhood_athlete"
    });

        public void EscapeDrawArrowsOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_gracious",
      "act_childhood_sharp"
    });

        public void EscapeFastHorseOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_tough",
      "act_childhood_decisive"
    });

        public void EscapeRoadOffWithBrotherOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_ready",
      "act_childhood_tough"
    });

        public void EscapeOrganizeTravellersOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_manners",
      "act_childhood_gracious"
    });

        public void EscapeSubdueRaiderOnApply(CharacterCreation characterCreation)
        {
        }

        public void EscapeDrawArrowsOnApply(CharacterCreation characterCreation)
        {
        }

        public void EscapeFastHorseOnApply(CharacterCreation characterCreation)
        {
        }

        public void EscapeRoadOffWithBrotherOnApply(CharacterCreation characterCreation)
        {
        }

        public void EscapeOrganizeTravellersOnApply(CharacterCreation characterCreation)
        {
        }

        public void ClearMountEntity(CharacterCreation characterCreation) => characterCreation.ClearFaceGenMounts();

        public void ClearCharacters(CharacterCreation characterCreation) => characterCreation.ClearFaceGenChars();

        public void CreateSibling(Hero hero)
        {
            BodyProperties bodyProperties = BodyProperties.GetRandomBodyProperties(hero.CharacterObject.Race, hero.IsFemale, CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.MotherFacegenCharacter.BodyProperties, CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.FatherFacegenCharacter.BodyProperties, 1, Hero.MainHero.Mother.CharacterObject.GetDefaultFaceSeed(1), hero.IsFemale ? Hero.MainHero.Mother.HairTags : Hero.MainHero.Father.HairTags, hero.IsFemale ? Hero.MainHero.Mother.BeardTags : Hero.MainHero.Father.BeardTags, hero.IsFemale ? Hero.MainHero.Mother.TattooTags : Hero.MainHero.Father.TattooTags);
            bodyProperties = new BodyProperties(new DynamicBodyProperties(hero.Age, 0.5f, 0.5f), bodyProperties.StaticProperties);
            hero.ModifyPlayersFamilyAppearance(bodyProperties.StaticProperties);
            hero.Weight = bodyProperties.Weight;
            hero.Build = bodyProperties.Build;
        }
    }
}
