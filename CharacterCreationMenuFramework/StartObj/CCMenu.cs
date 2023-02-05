using Messages.FromClient.ToLobbyServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;

namespace CharacterCreationMenuFramework.StartObj
{
    /*
     * _menu = new FamilyMenu("family", "{=b4lDDcli}Kaoses Family", "{=XgFU1pCx}You were born into a family of...", new CharacterCreationOnInit(this.ParentsOnInit));
     */
    public abstract class CCMenu
    {
        public string Id = "";
        public string title = "";
        public string description = "";
        public menuOperationMode _operationMode;
        public CharacterCreationOnInit creationOnInit;
        public string textVariable = "";
        public int variableValue = 0;

        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> restrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public List<CMenuOption> optionsList = new List<CMenuOption>();

        //protected CharacterCreationMenu _menu;

        public CCMenu(string stringId, string Title, string Description, CharacterCreationOnInit OnInit, menuOperationMode operationMode = menuOperationMode.Add)
        {
            Id = stringId;
            title = Title;
            description = Description;
            creationOnInit = OnInit;
            _operationMode = operationMode;

            /*            CharacterCreationMenu _menu = new CharacterCreationMenu(
                            new TextObject(Title),
                            new TextObject(Description),
                            new CharacterCreationOnInit(OnInit));*/
        }

        //AddCategoryOption(TextObject text,
        //MBList<SkillObject> effectedSkills,
        //CharacterAttribute effectedAttribute,
        //int focusToAdd, int skillLevelToAdd,
        //int attributeLevelToAdd,
        //CharacterCreationOnCondition optionCondition,
        //CharacterCreationOnSelect onSelect,
        //CharacterCreationApplyFinalEffects onApply,
        //TextObject descriptionText = null,
        //List<TraitObject> effectedTraits = null,
        //int traitLevelToAdd = 0,
        //int renownToAdd = 0,
        //int goldToAdd = 0,
        //int unspentFocusPoint = 0,
        //int unspentAttributePoint = 0)
        public void AddRestrictedOptions(CharacterCreationOnCondition creationCondition, List<CMenuOption> Options)
        {
            restrictedOptions.Add(creationCondition, Options);
            //CharacterCreationCategory creationCategory1 = menu.AddMenuCategory(new CharacterCreationOnCondition(this.EmpireParentsOnCondition));

            //()
            /*            creationCategory1.AddCategoryOption(new TextObject("{=InN5ZZt3}A landlord's retainers"), new MBList<SkillObject>()
                          {
                            DefaultSkills.Riding,
                            DefaultSkills.Polearm
                          },
                          DefaultCharacterAttributes.Vigor,
                          this.FocusToAdd, this.SkillLevelToAdd,
                          this.AttributeLevelToAdd,
                          (CharacterCreationOnCondition)null,
                          new CharacterCreationOnSelect(this.EmpireLandlordsRetainerOnConsequence),
                          new CharacterCreationApplyFinalEffects(this.EmpireLandlordsRetainerOnApply),
                          new TextObject("{=ivKl4mV2}Your father was a trusted lieutenant of the local landowning aristocrat. He rode with the lord's cavalry, fighting as an armored lancer."));
            */
        }

        public void AddOption(CMenuOption Option)
        {
            optionsList.Add(Option);
        }
    }
}
