using CharacterCreationMenuFramework.Interfaces;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.StartObj;
using static CharacterCreationMenuFramework.Enums;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.Library;

namespace CharacterCreationMenuFramework.NativeMenus
{
    public class Youth : ICustomMenu
    {
        public string Id => "native_youth";
        public TextObject title => new TextObject("{=ok8lSW6M}Native Youth");
        /*        private TextObject _title = new TextObject("{=b4lDDcli}Kaoses Family");
                public TextObject title { get => _title; set => _title = value }*/

        public TextObject description => new TextObject("{=XgFU1pCx}Test You were born into a family of...");
        public menuOperationMode OperationMode => menuOperationMode.Add;
        public Operationposition OperationPosition => Operationposition.Default;
        public string OperationmenuId => "native_youth";
        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.YouthOnInit);
        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;
        public string textVariable => "";
        public int variableValue => 0;

        public TextObject _youthIntroductoryText = new TextObject("{=!}{YOUTH_INTRO}");



        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            BuildYouthOptions(characterCreation, characterCreationContent);
        }

        public void RegisterMenu(MenuManager menuManager)
        {
            //menuManager.RegisterMenuObject(this);
        }

        public void RegisterOptions(MenuManager menuManager)
        {
            //throw new NotImplementedException();
        }

        public void BuildYouthOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            CMenuOption menuCommandersStaff = new CMenuOption(new TextObject("{=CITG915d}joined a commander's staff."), new TextObject("{=Ay0G3f7I}Your family arranged for you to be part of the staff of an imperial strategos. You were not given major responsibilities - mostly carrying messages and tending to his horse -- but it did give you a chance to see how campaigns were planned and men were deployed in battle."));
            menuCommandersStaff.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Steward,
                    DefaultSkills.Tactics
                  }; //MBList<SkillObject>
            menuCommandersStaff.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuCommandersStaff.focusToAdd = characterCreationContent.FocusToAdd;
            menuCommandersStaff.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuCommandersStaff.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuCommandersStaff.optionCondition = new CharacterCreationOnCondition(this.YouthCommanderOnCondition);//CharacterCreationOnCondition
            menuCommandersStaff.onSelect = new CharacterCreationOnSelect(this.YouthCommanderOnConsequence);//CharacterCreationOnSelect
            menuCommandersStaff.onApply = new CharacterCreationApplyFinalEffects(this.YouthCommanderOnApply);//CharacterCreationApplyFinalEffects
            menuCommandersStaff.Id = "ny_commandersstaff";

            CMenuOption menuBaronsGroom = new CMenuOption(new TextObject("{=bhE2i6OU}served as a baron's groom."), new TextObject("{=iZKtGI6Y}Your family arranged for you to accompany a minor baron of the Vlandian kingdom. You were not given major responsibilities - mostly carrying messages and tending to his horse -- but it did give you a chance to see how campaigns were planned and men were deployed in battle."));
            menuBaronsGroom.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Steward,
                    DefaultSkills.Tactics
                  }; //MBList<SkillObject>
            menuBaronsGroom.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuBaronsGroom.focusToAdd = characterCreationContent.FocusToAdd;
            menuBaronsGroom.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBaronsGroom.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBaronsGroom.optionCondition = new CharacterCreationOnCondition(this.YouthGroomOnCondition);//CharacterCreationOnCondition
            menuBaronsGroom.onSelect = new CharacterCreationOnSelect(this.YouthGroomOnConsequence);//CharacterCreationOnSelect
            menuBaronsGroom.onApply = new CharacterCreationApplyFinalEffects(this.YouthGroomOnApply);//CharacterCreationApplyFinalEffects
            menuBaronsGroom.Id = "ny_baronsgroom";

            CMenuOption menuChieftainsServant = new CMenuOption(new TextObject("{=F2bgujPo}were a chieftain's servant."), new TextObject("{=7AYJ3SjK}Your family arranged for you to accompany a chieftain of your people. You were not given major responsibilities - mostly carrying messages and tending to his horse -- but it did give you a chance to see how campaigns were planned and men were deployed in battle."));
            menuChieftainsServant.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Steward,
                    DefaultSkills.Tactics
                  }; //MBList<SkillObject>
            menuChieftainsServant.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuChieftainsServant.focusToAdd = characterCreationContent.FocusToAdd;
            menuChieftainsServant.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuChieftainsServant.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuChieftainsServant.optionCondition = new CharacterCreationOnCondition(this.YouthChieftainOnCondition);//CharacterCreationOnCondition
            menuChieftainsServant.onSelect = new CharacterCreationOnSelect(this.YouthChieftainOnConsequence);//CharacterCreationOnSelect
            menuChieftainsServant.onApply = new CharacterCreationApplyFinalEffects(this.YouthChieftainOnApply);//CharacterCreationApplyFinalEffects
            menuChieftainsServant.Id = "ny_chieftainsservant";

            CMenuOption menuTrainedWithCavalry = new CMenuOption(new TextObject("{=h2KnarLL}trained with the cavalry."), new TextObject("{=7cHsIMLP}You could never have bought the equipment on your own, but you were a good enough rider so that the local lord lent you a horse and equipment. You joined the armored cavalry, training with the lance."));
            menuTrainedWithCavalry.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Polearm
                  }; //MBList<SkillObject>
            menuTrainedWithCavalry.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuTrainedWithCavalry.focusToAdd = characterCreationContent.FocusToAdd;
            menuTrainedWithCavalry.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuTrainedWithCavalry.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuTrainedWithCavalry.optionCondition = new CharacterCreationOnCondition(this.YouthCavalryOnCondition);//CharacterCreationOnCondition
            menuTrainedWithCavalry.onSelect = new CharacterCreationOnSelect(this.YouthCavalryOnConsequence);//CharacterCreationOnSelect
            menuTrainedWithCavalry.onApply = new CharacterCreationApplyFinalEffects(this.YouthCavalryOnApply);//CharacterCreationApplyFinalEffects
            menuTrainedWithCavalry.Id = "ny_trainedwithcavalry";

            CMenuOption menuTrainedWithHearthGuard = new CMenuOption(new TextObject("{=zsC2t5Hb}trained with the hearth guard."), new TextObject("{=RmbWW6Bm}You were a big and imposing enough youth that the chief's guard allowed you to train alongside them, in preparation to join them some day."));
            menuTrainedWithHearthGuard.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Polearm
                  }; //MBList<SkillObject>
            menuTrainedWithHearthGuard.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuTrainedWithHearthGuard.focusToAdd = characterCreationContent.FocusToAdd;
            menuTrainedWithHearthGuard.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuTrainedWithHearthGuard.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuTrainedWithHearthGuard.optionCondition = new CharacterCreationOnCondition(this.YouthHearthGuardOnCondition);//CharacterCreationOnCondition
            menuTrainedWithHearthGuard.onSelect = new CharacterCreationOnSelect(this.YouthHearthGuardOnConsequence);//CharacterCreationOnSelect
            menuTrainedWithHearthGuard.onApply = new CharacterCreationApplyFinalEffects(this.YouthHearthGuardOnApply);//CharacterCreationApplyFinalEffects
            menuTrainedWithHearthGuard.Id = "ny_trainedwithhearthguard";

            CMenuOption menuGuardWithGarrison = new CMenuOption(new TextObject("{=aTncHUfL}stood guard with the garrisons."), new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges."));
            menuGuardWithGarrison.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Crossbow,
                    DefaultSkills.Engineering
                  }; //MBList<SkillObject>
            menuGuardWithGarrison.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuGuardWithGarrison.focusToAdd = characterCreationContent.FocusToAdd;
            menuGuardWithGarrison.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuGuardWithGarrison.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuGuardWithGarrison.optionCondition = new CharacterCreationOnCondition(this.YouthGarrisonOnCondition);//CharacterCreationOnCondition
            menuGuardWithGarrison.onSelect = new CharacterCreationOnSelect(this.YouthGarrisonOnConsequence);//CharacterCreationOnSelect
            menuGuardWithGarrison.onApply = new CharacterCreationApplyFinalEffects(this.YouthGarrisonOnApply);//CharacterCreationApplyFinalEffects
            menuGuardWithGarrison.Id = "ny_guardwithgarrison";

            CMenuOption menuGuardWithGarrison2 = new CMenuOption(new TextObject("{=aTncHUfL}stood guard with the garrisons."), new TextObject("{=1EkEElZd}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons."));
            menuGuardWithGarrison2.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Bow,
                    DefaultSkills.Engineering
                  }; //MBList<SkillObject>
            menuGuardWithGarrison2.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuGuardWithGarrison2.focusToAdd = characterCreationContent.FocusToAdd;
            menuGuardWithGarrison2.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuGuardWithGarrison2.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuGuardWithGarrison2.optionCondition = new CharacterCreationOnCondition(this.YouthOtherGarrisonOnCondition);//CharacterCreationOnCondition
            menuGuardWithGarrison2.onSelect = new CharacterCreationOnSelect(this.YouthOtherGarrisonOnConsequence);//CharacterCreationOnSelect
            menuGuardWithGarrison2.onApply = new CharacterCreationApplyFinalEffects(this.YouthOtherGarrisonOnApply);//CharacterCreationApplyFinalEffects
            menuGuardWithGarrison2.Id = "ny_guardwithgarrisonother";

            CMenuOption menuRodeWithScouts = new CMenuOption(new TextObject("{=VlXOgIX6}rode with the scouts."), new TextObject("{=888lmJqs}All of Calradia's kingdoms recognize the value of good light cavalry and horse archers, and are sure to recruit nomads and borderers with the skills to fulfill those duties. You were a good enough rider that your neighbors pitched in to buy you a small pony and a good bow so that you could fulfill their levy obligations."));
            menuRodeWithScouts.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Bow
                  }; //MBList<SkillObject>
            menuRodeWithScouts.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuRodeWithScouts.focusToAdd = characterCreationContent.FocusToAdd;
            menuRodeWithScouts.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuRodeWithScouts.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuRodeWithScouts.optionCondition = new CharacterCreationOnCondition(this.YouthOutridersOnCondition);//CharacterCreationOnCondition
            menuRodeWithScouts.onSelect = new CharacterCreationOnSelect(this.YouthOutridersOnConsequence);//CharacterCreationOnSelect
            menuRodeWithScouts.onApply = new CharacterCreationApplyFinalEffects(this.YouthOutridersOnApply);//CharacterCreationApplyFinalEffects
            menuRodeWithScouts.Id = "ny_rodewithscouts";

            CMenuOption menuRodeWithScouts2 = new CMenuOption(new TextObject("{=VlXOgIX6}rode with the scouts."), new TextObject("{=sYuN6hPD}All of Calradia's kingdoms recognize the value of good light cavalry, and are sure to recruit nomads and borderers with the skills to fulfill those duties. You were a good enough rider that your neighbors pitched in to buy you a small pony and a sheaf of javelins so that you could fulfill their levy obligations."));
            menuRodeWithScouts2.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Bow
                  }; //MBList<SkillObject>
            menuRodeWithScouts2.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuRodeWithScouts2.focusToAdd = characterCreationContent.FocusToAdd;
            menuRodeWithScouts2.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuRodeWithScouts2.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuRodeWithScouts2.optionCondition = new CharacterCreationOnCondition(this.YouthOtherOutridersOnCondition);//CharacterCreationOnCondition
            menuRodeWithScouts2.onSelect = new CharacterCreationOnSelect(this.YouthOtherOutridersOnConsequence);//CharacterCreationOnSelect
            menuRodeWithScouts2.onApply = new CharacterCreationApplyFinalEffects(this.YouthOtherOutridersOnApply);//CharacterCreationApplyFinalEffects
            menuRodeWithScouts2.Id = "ny_rodewithscoutsother";

            CMenuOption menuTrainedWithInfantry = new CMenuOption(new TextObject("{=a8arFSra}trained with the infantry."), new TextObject("{=afH90aNs}Levy armed with spear and shield, drawn from smallholding farmers, have always been the backbone of most armies of Calradia."));
            menuTrainedWithInfantry.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Polearm,
                    DefaultSkills.OneHanded
                  }; //MBList<SkillObject>
            menuTrainedWithInfantry.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuTrainedWithInfantry.focusToAdd = characterCreationContent.FocusToAdd;
            menuTrainedWithInfantry.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuTrainedWithInfantry.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuTrainedWithInfantry.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuTrainedWithInfantry.onSelect = new CharacterCreationOnSelect(this.YouthInfantryOnConsequence);//CharacterCreationOnSelect
            menuTrainedWithInfantry.onApply = new CharacterCreationApplyFinalEffects(this.YouthInfantryOnApply);//CharacterCreationApplyFinalEffects
            menuTrainedWithInfantry.Id = "ny_trainedwithinfantry";

            CMenuOption menuJoinedSkirmishers = new CMenuOption(new TextObject("{=oMbOIPc9}joined the skirmishers."), new TextObject("{=bXAg5w19}Younger recruits, or those of a slighter build, or those too poor to buy shield and armor tend to join the skirmishers. Fighting with bow and javelin, they try to stay out of reach of the main enemy forces."));
            menuJoinedSkirmishers.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Throwing,
                    DefaultSkills.OneHanded
                  }; //MBList<SkillObject>
            menuJoinedSkirmishers.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuJoinedSkirmishers.focusToAdd = characterCreationContent.FocusToAdd;
            menuJoinedSkirmishers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuJoinedSkirmishers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuJoinedSkirmishers.optionCondition = new CharacterCreationOnCondition(this.YouthSkirmisherOnCondition);//CharacterCreationOnCondition
            menuJoinedSkirmishers.onSelect = new CharacterCreationOnSelect(this.YouthSkirmisherOnConsequence);//CharacterCreationOnSelect
            menuJoinedSkirmishers.onApply = new CharacterCreationApplyFinalEffects(this.YouthSkirmisherOnApply);//CharacterCreationApplyFinalEffects
            menuJoinedSkirmishers.Id = "ny_joinedskirmishers";

            CMenuOption menuJoinedKern = new CMenuOption(new TextObject("{=cDWbwBwI}joined the kern."), new TextObject("{=tTb28jyU}Many Battanians fight as kern, versatile troops who could both harass the enemy line with their javelins or join in the final screaming charge once it weakened."));
            menuJoinedKern.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Throwing,
                    DefaultSkills.OneHanded
                  }; //MBList<SkillObject>
            menuJoinedKern.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuJoinedKern.focusToAdd = characterCreationContent.FocusToAdd;
            menuJoinedKern.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuJoinedKern.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuJoinedKern.optionCondition = new CharacterCreationOnCondition(this.YouthKernOnCondition);//CharacterCreationOnCondition
            menuJoinedKern.onSelect = new CharacterCreationOnSelect(this.YouthKernOnConsequence);//CharacterCreationOnSelect
            menuJoinedKern.onApply = new CharacterCreationApplyFinalEffects(this.YouthKernOnApply);//CharacterCreationApplyFinalEffects
            menuJoinedKern.Id = "ny_joinedker";

            CMenuOption menuCampFollowers = new CMenuOption(new TextObject("{=GFUggps8}marched with the camp followers."), new TextObject("{=64rWqBLN}You avoided service with one of the main forces of your realm's armies, but followed instead in the train - the troops' wives, lovers and servants, and those who make their living by caring for, entertaining, or cheating the soldiery."));
            menuCampFollowers.effectedSkills = new MBList<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.Throwing
                  }; //MBList<SkillObject>
            menuCampFollowers.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuCampFollowers.focusToAdd = characterCreationContent.FocusToAdd;
            menuCampFollowers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuCampFollowers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuCampFollowers.optionCondition = new CharacterCreationOnCondition(this.YouthCamperOnCondition);//CharacterCreationOnCondition
            menuCampFollowers.onSelect = new CharacterCreationOnSelect(this.YouthCamperOnConsequence);//CharacterCreationOnSelect
            menuCampFollowers.onApply = new CharacterCreationApplyFinalEffects(this.YouthCamperOnApply);//CharacterCreationApplyFinalEffects
            menuCampFollowers.Id = "ny_marchedwithcampfollowers";

            OptionsList.Add(menuCommandersStaff);
            OptionsList.Add(menuBaronsGroom);
            OptionsList.Add(menuChieftainsServant);
            OptionsList.Add(menuTrainedWithCavalry);
            OptionsList.Add(menuTrainedWithHearthGuard);
            OptionsList.Add(menuGuardWithGarrison);
            OptionsList.Add(menuGuardWithGarrison2);
            OptionsList.Add(menuRodeWithScouts);
            OptionsList.Add(menuRodeWithScouts2);
            OptionsList.Add(menuTrainedWithInfantry);
            OptionsList.Add(menuJoinedSkirmishers);
            OptionsList.Add(menuJoinedKern);
            OptionsList.Add(menuCampFollowers);
        }


        public void YouthOnInit(CharacterCreation characterCreation)
        {
            characterCreation.IsPlayerAlone = true;
            characterCreation.HasSecondaryCharacter = false;
            characterCreation.ClearFaceGenPrefab();
            TextObject textObject1 = new TextObject("{=F7OO5SAa}As a youngster growing up in Calradia, war was never too far away. You...");
            TextObject textObject2 = new TextObject("{=5kbeAC7k}In wartorn Calradia, especially in frontier or tribal areas, some women as well as men learn to fight from an early age. You...");
            this._youthIntroductoryText.SetTextVariable("YOUTH_INTRO", CharacterObject.PlayerCharacter.IsFemale ? textObject2 : textObject1);
            characterCreation.ChangeFaceGenChars(CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.ChangePlayerFaceWithAge((float)CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.YouthAge));
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_schooled"
      });
            if (CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType < 1 || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType > 10)
                CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 1;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
        }


        public bool YouthCommanderOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "empire" && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer;

        public void YouthCommanderOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthGroomOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "vlandia" && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer;

        public void YouthCommanderOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 10;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_decisive"
      });
        }

        public void YouthGroomOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 10;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_sharp"
      });
        }

        public void YouthChieftainOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 10;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_ready"
      });
        }

        public void YouthCavalryOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 9;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_apprentice"
      });
        }

        public void YouthHearthGuardOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 9;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_athlete"
      });
        }

        public void YouthOutridersOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 2;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_gracious"
      });
        }

        public void YouthOtherOutridersOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 2;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_gracious"
      });
        }

        public void YouthInfantryOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 3;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_fierce"
      });
        }

        public void YouthSkirmisherOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 4;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_fox"
      });
        }

        public void YouthGarrisonOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 1;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_vibrant"
      });
        }

        public void YouthOtherGarrisonOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 1;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_sharp"
      });
        }

        public void YouthKernOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 8;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_apprentice"
      });
        }

        public void YouthCamperOnConsequence(CharacterCreation characterCreation)
        {
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SelectedTitleType = 5;
            CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.RefreshPlayerAppearance(characterCreation);
            characterCreation.ChangeCharsAnimation(new List<string>()
      {
        "act_childhood_militia"
      });
        }

        public void YouthGroomOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthChieftainOnCondition() => (CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "battania" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "khuzait") && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType == KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer;

        public void YouthChieftainOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthCavalryOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "empire" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "khuzait" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "aserai" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "vlandia";

        public void YouthCavalryOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthHearthGuardOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "sturgia" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "battania";

        public void YouthHearthGuardOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthOutridersOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "empire" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "khuzait";

        public void YouthOutridersOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthOtherOutridersOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId != "empire" && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId != "khuzait";

        public void YouthOtherOutridersOnApply(CharacterCreation characterCreation)
        {
        }

        public void YouthInfantryOnApply(CharacterCreation characterCreation)
        {
        }

        public void YouthSkirmisherOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthGarrisonOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "empire" || CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "vlandia";

        public void YouthGarrisonOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthOtherGarrisonOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId != "empire" && CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId != "vlandia";

        public void YouthOtherGarrisonOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthSkirmisherOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId != "battania";

        public bool YouthKernOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "battania";

        public void YouthKernOnApply(CharacterCreation characterCreation)
        {
        }

        public bool YouthCamperOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation._familyOccupationType != KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer;

        public void YouthCamperOnApply(CharacterCreation characterCreation)
        {
        }

    }
}
