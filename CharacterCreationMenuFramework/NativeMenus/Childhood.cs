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
    public class Childhood : ICustomMenu
    {
        public string Id => "native_childhood";

        public TextObject title => new TextObject("{=8Yiwt1z6}Early Childhood");

        public TextObject description => new TextObject("{=character_creation_content_16}As a child you were noted for...");

        public menuOperationMode OperationMode => menuOperationMode.Add;
        public Operationposition OperationPosition => Operationposition.Default;
        public string OperationmenuId => "native_childhood";

        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.ChildhoodOnInit);

        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;
        public string textVariable => "";
        public int variableValue => 0;

        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            BuildChildHoodOptions(characterCreation, characterCreationContent);

        }

        public void RegisterMenu(MenuManager menuManager)
        {
            //menuManager.RegisterMenuObject(this);
            //throw new NotImplementedException();
        }

        public void RegisterOptions(MenuManager menuManager)
        {
            //throw new NotImplementedException();
        }

        public void BuildChildHoodOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            List<CMenuOption> empireOptinonsList = new List<CMenuOption>();

            CMenuOption menuleadership = new CMenuOption(new TextObject("{=kmM68Qx4}your leadership skills."), new TextObject("{=FfNwXtii}If the wolf pup gang of your early childhood had an alpha, it was definitely you. All the other kids followed your lead as you decided what to play and where to play, and led them in games and mischief."));
            menuleadership.effectedSkills = new List<SkillObject>(){
                                            DefaultSkills.Leadership,
                                            DefaultSkills.Tactics}; //List<SkillObject>
            menuleadership.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuleadership.focusToAdd = characterCreationContent.FocusToAdd;
            menuleadership.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuleadership.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuleadership.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuleadership.onSelect = new CharacterCreationOnSelect(this.ChildhoodYourLeadershipSkillsOnConsequence);//CharacterCreationOnSelect
            menuleadership.onApply = new CharacterCreationApplyFinalEffects(this.ChildhoodGoodLeadingOnApply);//CharacterCreationApplyFinalEffects
            menuleadership.Id = "nc_leadershipskills";

            CMenuOption menuBrawn = new CMenuOption(new TextObject("{=5HXS8HEY}your brawn."), new TextObject("{=YKzuGc54}You were big, and other children looked to have you around in any scrap with children from a neighboring village. You pushed a plough and threw an axe like an adult."));
            menuBrawn.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.TwoHanded,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuBrawn.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuBrawn.focusToAdd = characterCreationContent.FocusToAdd;
            menuBrawn.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBrawn.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBrawn.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuBrawn.onSelect = new CharacterCreationOnSelect(this.ChildhoodYourBrawnOnConsequence);//CharacterCreationOnSelect
            menuBrawn.onApply = new CharacterCreationApplyFinalEffects(this.ChildhoodGoodAthleticsOnApply);//CharacterCreationApplyFinalEffects
            menuBrawn.Id = "nc_yourbrawn";

            CMenuOption menuAttention = new CMenuOption(new TextObject("{=QrYjPUEf}your attention to detail."), new TextObject("{=JUSHAPnu}You were quick on your feet and attentive to what was going on around you. Usually you could run away from trouble, though you could give a good account of yourself in a fight with other children if cornered."));
            menuAttention.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Bow
                  }; //List<SkillObject>
            menuAttention.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuAttention.focusToAdd = characterCreationContent.FocusToAdd;
            menuAttention.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuAttention.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuAttention.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuAttention.onSelect = new CharacterCreationOnSelect(this.ChildhoodAttentionToDetailOnConsequence);//CharacterCreationOnSelect
            menuAttention.onApply = new CharacterCreationApplyFinalEffects(this.ChildhoodGoodMemoryOnApply);//CharacterCreationApplyFinalEffects
            menuAttention.Id = "nc_attentiontodetail";

            CMenuOption menuAptitude = new CMenuOption(new TextObject("{=Y3UcaX74}your aptitude for numbers."), new TextObject("{=DFidSjIf}Most children around you had only the most rudimentary education, but you lingered after class to study letters and mathematics. You were fascinated by the marketplace - weights and measures, tallies and accounts, the chatter about profits and losses."));
            menuAptitude.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Engineering,
                    DefaultSkills.Trade
                  }; //List<SkillObject>
            menuAptitude.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuAptitude.focusToAdd = characterCreationContent.FocusToAdd;
            menuAptitude.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuAptitude.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuAptitude.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuAptitude.onSelect = new CharacterCreationOnSelect(this.ChildhoodAptitudeForNumbersOnConsequence);//CharacterCreationOnSelect
            menuAptitude.onApply = new CharacterCreationApplyFinalEffects(this.ChildhoodGoodMathOnApply);//CharacterCreationApplyFinalEffects
            menuAptitude.Id = "nc_aptitudefornumbers";

            CMenuOption menuCharm = new CMenuOption(new TextObject("{=GEYzLuwb}your way with people."), new TextObject("{=w2TEQq26}You were always attentive to other people, good at guessing their motivations. You studied how individuals were swayed, and tried out what you learned from adults on your friends."));
            menuCharm.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Charm,
                    DefaultSkills.Leadership
                  }; //List<SkillObject>
            menuCharm.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuCharm.focusToAdd = characterCreationContent.FocusToAdd;
            menuCharm.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuCharm.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuCharm.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuCharm.onSelect = new CharacterCreationOnSelect(this.ChildhoodWayWithPeopleOnConsequence);//CharacterCreationOnSelect
            menuCharm.onApply = new CharacterCreationApplyFinalEffects(this.ChildhoodGoodMannersOnApply);//CharacterCreationApplyFinalEffects
            menuCharm.Id = "nc_waywithpeople";

            CMenuOption menuHorses = new CMenuOption(new TextObject("{=MEgLE2kj}your skill with horses."), new TextObject("{=ngazFofr}You were always drawn to animals, and spent as much time as possible hanging out in the village stables. You could calm horses, and were sometimes called upon to break in new colts. You learned the basics of veterinary arts, much of which is applicable to humans as well."));
            menuHorses.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Medicine
                  }; //List<SkillObject>
            menuHorses.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuHorses.focusToAdd = characterCreationContent.FocusToAdd;
            menuHorses.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuHorses.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuHorses.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuHorses.onSelect = new CharacterCreationOnSelect(this.ChildhoodSkillsWithHorsesOnConsequence);//CharacterCreationOnSelect
            menuHorses.onApply = new CharacterCreationApplyFinalEffects(this.ChildhoodAffinityWithAnimalsOnApply);//CharacterCreationApplyFinalEffects
            menuHorses.Id = "nc_skillwithhorses";

            OptionsList.Add(menuleadership);
            OptionsList.Add(menuBrawn);
            OptionsList.Add(menuAttention);
            OptionsList.Add(menuAptitude);
            OptionsList.Add(menuCharm);
            OptionsList.Add(menuHorses);

        }


        public void ChildhoodOnInit(CharacterCreation characterCreation)
        {
            characterCreation.IsPlayerAlone = true;
            characterCreation.HasSecondaryCharacter = false;
            characterCreation.ClearFaceGenPrefab();
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge((float)CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChildhoodAge));
            string outfit = "player_char_creation_childhood_age_" + CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId + "_" + (object)CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedParentType + (Hero.MainHero.IsFemale ? "_f" : "_m");
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerOutfit(characterCreation, outfit);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_schooled"
      });
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ClearMountEntity(characterCreation);
        }

        public void ChildhoodYourLeadershipSkillsOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_leader"
    });

        public void ChildhoodYourBrawnOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_athlete"
    });

        public void ChildhoodAttentionToDetailOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_memory"
    });

        public void ChildhoodAptitudeForNumbersOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_numbers"
    });

        public void ChildhoodWayWithPeopleOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_manners"
    });

        public void ChildhoodSkillsWithHorsesOnConsequence(CharacterCreation characterCreation) => characterCreation.ChangeCharsAnimation(new List<string>()
    {
      "act_childhood_animals"
    });
        public void ChildhoodGoodLeadingOnApply(CharacterCreation characterCreation)
        {

        }

        public void ChildhoodGoodAthleticsOnApply(CharacterCreation characterCreation)
        {
        }

        public void ChildhoodGoodMemoryOnApply(CharacterCreation characterCreation)
        {
        }

        public void ChildhoodGoodMathOnApply(CharacterCreation characterCreation)
        {
        }

        public void ChildhoodGoodMannersOnApply(CharacterCreation characterCreation)
        {
        }

        public void ChildhoodAffinityWithAnimalsOnApply(CharacterCreation characterCreation)
        {
        }
    }
}
