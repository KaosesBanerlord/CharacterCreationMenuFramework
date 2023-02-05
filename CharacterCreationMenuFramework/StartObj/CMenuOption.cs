using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace CharacterCreationMenuFramework.StartObj
{
    public class CMenuOption
    {
        public string Id = "";
        public TextObject optionText = new TextObject("");
        public TextObject descriptionText = new TextObject("");

        public List<SkillObject> effectedSkills = new List<SkillObject>();
        public CharacterAttribute effectedAttribute = DefaultCharacterAttributes.Social;
        public int focusToAdd = 0;
        public int skillLevelToAdd = 0;
        public int attributeLevelToAdd = 0;
        public CharacterCreationOnCondition optionCondition = (CharacterCreationOnCondition)null;
        public CharacterCreationOnSelect onSelect = (CharacterCreationOnSelect)null;
        public CharacterCreationApplyFinalEffects onApply = (CharacterCreationApplyFinalEffects)null;
        public List<TraitObject> effectedTraits = new List<TraitObject>();
        public int traitLevelToAdd = 0;
        public int renownToAdd = 0;
        public int goldToAdd = 0;
        public int unspentFocusPoint = 0;
        public int unspentAttributePoint = 0;

        public CMenuOption(TextObject OptionText, TextObject DescriptionText = null)
        {
            optionText = OptionText;
            descriptionText = DescriptionText;
        }
    }
}
