using KaosesCommon.Utils;
using CharacterCreationMenuFramework.Interfaces;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.StartObj;
using static CharacterCreationMenuFramework.Enums;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CharacterCreationMenuFramework.NativeMenus
{
    public class FamilyMenu : ICustomMenu
    {
        public string Id => "native_family";
        public TextObject title => new TextObject("{=b4lDDcli}Family");
        /*        private TextObject _title = new TextObject("{=b4lDDcli}Kaoses Family");
                public TextObject title { get => _title; set => _title = value }*/

        public TextObject description => new TextObject("{=XgFU1pCx}Test You were born into a family of...");
        public menuOperationMode OperationMode => menuOperationMode.Add;
        public Operationposition OperationPosition => Operationposition.Default;
        public string OperationmenuId => "native_family";
        public CharacterCreationOnInit CreationOnInit => new CharacterCreationOnInit(this.ParentsOnInit);
        protected Dictionary<CharacterCreationOnCondition, List<CMenuOption>> _RestrictedOptions = new Dictionary<CharacterCreationOnCondition, List<CMenuOption>>();
        public Dictionary<CharacterCreationOnCondition, List<CMenuOption>> RestrictedOptions => _RestrictedOptions;
        protected List<CMenuOption> _OptionsList = new List<CMenuOption>();
        public List<CMenuOption> OptionsList => _OptionsList;
        public string textVariable => "";
        public int variableValue => 0;

        public FamilyMenu()
        {

        }

        public void Initialise(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            BuildFamilyMenuOptions(characterCreation, characterCreationContent);
            //test();
        }

        public void RegisterMenu(MenuManager menuManager)
        {
            //menuManager.RegisterMenuObject(this);
        }

        public void RegisterOptions(MenuManager menuManager)
        {
            menuManager.RegisterMenuObject(this);
        }

        public void test()
        {

            foreach (KeyValuePair<CharacterCreationOnCondition, List<CMenuOption>> pair in RestrictedOptions)
            {
                IM.MessageDebug("FamilyMenu :First Dictionary Foreach loop");
                CharacterCreationOnCondition condition = pair.Key;
                List<CMenuOption> optionList = pair.Value;
                IM.MessageDebug("FamilyMenu :condition : " + condition.ToString());
                IM.MessageDebug("FamilyMenu :optionList.Count : " + optionList.Count);
                foreach (CMenuOption option in optionList)
                {
                    IM.MessageDebug("FamilyMenu : " +
                        "Menu ID: " + option.optionText +
                        "focusToAdd: " + option.focusToAdd +
                        "skillLevelToAdd: " + option.skillLevelToAdd +
                        "attributeLevelToAdd: " + option.attributeLevelToAdd +
                        //"effectedTraits: " + option.effectedTraits.ToString() +
                        //"effectedSkills: " + option.effectedSkills.ToString() +
                        // "effectedAttribute: " + option.effectedAttribute.ToString() +
                        "traitLevelToAdd: " + option.traitLevelToAdd +
                        "renownToAdd: " + option.renownToAdd +
                        "goldToAdd: " + option.goldToAdd +
                        "unspentFocusPoint: " + option.unspentFocusPoint +
                        "unspentAttributePoint: " + option.unspentAttributePoint +
                        "descriptionText: " + option.descriptionText
                        );
                }

            }
        }


        public void BuildFamilyMenuOptions(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            // CULTURE EQUALS EMPIRE MENU OPTIONS
            #region Empire Options
            List<CMenuOption> empireOptinonsList = new List<CMenuOption>();
            CMenuOption menulandlordsRetainers = new CMenuOption(new TextObject("{=InN5ZZt3}A landlord's retainers"), new TextObject("{=ivKl4mV2}Your father was a trusted lieutenant of the local landowning aristocrat. He rode with the lord's cavalry, fighting as an armored lancer."));
            menulandlordsRetainers.effectedSkills = new List<SkillObject>(){
                                            DefaultSkills.Riding,
                                            DefaultSkills.Polearm}; //List<SkillObject>
            menulandlordsRetainers.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menulandlordsRetainers.focusToAdd = characterCreationContent.FocusToAdd;
            menulandlordsRetainers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menulandlordsRetainers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menulandlordsRetainers.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menulandlordsRetainers.onSelect = new CharacterCreationOnSelect(this.EmpireLandlordsRetainerOnConsequence);//CharacterCreationOnSelect
            menulandlordsRetainers.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects
            menulandlordsRetainers.Id = "nf_landlordsRetainers";

            CMenuOption menuUrbanmerchants = new CMenuOption(new TextObject("{=651FhzdR}Urban merchants"), new TextObject("{=FQntPChs}Your family were merchants in one of the main cities of the Empire. They sometimes organized caravans to nearby towns, and discussed issues in the town council."));
            menuUrbanmerchants.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuUrbanmerchants.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuUrbanmerchants.focusToAdd = characterCreationContent.FocusToAdd;
            menuUrbanmerchants.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuUrbanmerchants.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuUrbanmerchants.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuUrbanmerchants.onSelect = new CharacterCreationOnSelect(this.EmpireMerchantOnConsequence);//CharacterCreationOnSelect
            menuUrbanmerchants.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects
            menuUrbanmerchants.Id = "nf_urbanmerchants";

            CMenuOption menuFreeholders = new CMenuOption(new TextObject("{=sb4gg8Ak}Freeholders"), new TextObject("{=09z8Q08f}Your family were small farmers with just enough land to feed themselves and make a small profit. People like them were the pillars of the imperial rural economy, as well as the backbone of the levy."));
            menuFreeholders.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Polearm
                  }; //List<SkillObject>
            menuFreeholders.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuFreeholders.focusToAdd = characterCreationContent.FocusToAdd;
            menuFreeholders.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuFreeholders.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuFreeholders.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuFreeholders.onSelect = new CharacterCreationOnSelect(this.EmpireFreeholderOnConsequence);//CharacterCreationOnSelect
            menuFreeholders.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects
            menuFreeholders.Id = "nf_freeholders";

            CMenuOption menuUrbanArtisans = new CMenuOption(new TextObject("{=v48N6h1t}Urban artisans"), new TextObject("{=ZKynvffv}Your family owned their own workshop in a city, making goods from raw materials brought in from the countryside. Your father played an active if minor role in the town council, and also served in the militia."));
            menuUrbanArtisans.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Crafting,
                    DefaultSkills.Crossbow
                  }; //List<SkillObject>
            menuUrbanArtisans.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuUrbanArtisans.focusToAdd = characterCreationContent.FocusToAdd;
            menuUrbanArtisans.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuUrbanArtisans.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuUrbanArtisans.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuUrbanArtisans.onSelect = new CharacterCreationOnSelect(this.EmpireArtisanOnConsequence);//CharacterCreationOnSelect
            menuUrbanArtisans.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects
            menuUrbanArtisans.Id = "nf_";

            CMenuOption menuForesters = new CMenuOption(new TextObject("{=7eWmU2mF}Foresters"), new TextObject("{=yRFSzSDZ}Your family lived in a village, but did not own their own land. Instead, your father supplemented paid jobs with long trips in the woods, hunting and trapping, always keeping a wary eye for the lord's game wardens."));
            menuForesters.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Scouting,
                    DefaultSkills.Bow
                  }; //List<SkillObject>
            menuForesters.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuForesters.focusToAdd = characterCreationContent.FocusToAdd;
            menuForesters.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuForesters.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuForesters.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuForesters.onSelect = new CharacterCreationOnSelect(this.EmpireWoodsmanOnConsequence);//CharacterCreationOnSelect
            menuForesters.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects
            menuForesters.Id = "nf_foresters";

            CMenuOption menuUrbanVagabonds = new CMenuOption(new TextObject("{=aEke8dSb}Urban vagabonds"), new TextObject("{=Jvf6K7TZ}Your family numbered among the many poor migrants living in the slums that grow up outside the walls of imperial cities, making whatever money they could from a variety of odd jobs. Sometimes they did service for one of the Empire's many criminal gangs, and you had an early look at the dark side of life."));
            menuUrbanVagabonds.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuUrbanVagabonds.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuUrbanVagabonds.focusToAdd = characterCreationContent.FocusToAdd;
            menuUrbanVagabonds.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuUrbanVagabonds.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuUrbanVagabonds.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuUrbanVagabonds.onSelect = new CharacterCreationOnSelect(this.EmpireVagabondOnConsequence);//CharacterCreationOnSelect
            menuUrbanVagabonds.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects
            menuUrbanVagabonds.Id = "nf_urbanvagabonds";



            empireOptinonsList.Add(menulandlordsRetainers);
            empireOptinonsList.Add(menuUrbanmerchants);
            empireOptinonsList.Add(menuFreeholders);
            empireOptinonsList.Add(menuUrbanArtisans);
            empireOptinonsList.Add(menuForesters);
            empireOptinonsList.Add(menuUrbanVagabonds);


            RestrictedOptions.Add(new CharacterCreationOnCondition(this.EmpireParentsOnCondition), empireOptinonsList);
            #endregion

            // CULTURE EQUALS VLADIAN MENU OPTIONS
            #region Vladian Options
            List<CMenuOption> vlandianOptinonsList = new List<CMenuOption>();

            CMenuOption menuVladianbaronsRetainers = new CMenuOption(new TextObject("{=2TptWc4m}A baron's retainers"), new TextObject("{=0Suu1Q9q}Your father was a bailiff for a local feudal magnate. He looked after his liege's estates, resolved disputes in the village, and helped train the village levy. He rode with the lord's cavalry, fighting as an armored knight."));
            menuVladianbaronsRetainers.effectedSkills = new List<SkillObject>()
                      {
                        DefaultSkills.Riding,
                        DefaultSkills.Polearm
                      }; //List<SkillObject>
            menuVladianbaronsRetainers.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuVladianbaronsRetainers.focusToAdd = characterCreationContent.FocusToAdd;
            menuVladianbaronsRetainers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVladianbaronsRetainers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVladianbaronsRetainers.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuVladianbaronsRetainers.onSelect = new CharacterCreationOnSelect(this.VlandiaBaronsRetainerOnConsequence);//CharacterCreationOnSelect
            menuVladianbaronsRetainers.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuVladianUrbanMerchants = new CMenuOption(new TextObject("{=651FhzdR}Urban merchants"), new TextObject("{=qNZFkxJb}Your family were merchants in one of the main cities of the kingdom. They organized caravans to nearby towns and were active in the local merchant's guild."));
            menuVladianUrbanMerchants.effectedSkills = new List<SkillObject>()
                      {
                        DefaultSkills.Trade,
                        DefaultSkills.Charm
                      }; //List<SkillObject>
            menuVladianUrbanMerchants.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuVladianUrbanMerchants.focusToAdd = characterCreationContent.FocusToAdd;
            menuVladianUrbanMerchants.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVladianUrbanMerchants.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVladianUrbanMerchants.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuVladianUrbanMerchants.onSelect = new CharacterCreationOnSelect(this.VlandiaMerchantOnConsequence);//CharacterCreationOnSelect
            menuVladianUrbanMerchants.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuVladianYeomen = new CMenuOption(new TextObject("{=RDfXuVxT}Yeomen"), new TextObject("{=BLZ4mdhb}Your family were small farmers with just enough land to feed themselves and make a small profit. People like them were the pillars of the kingdom's economy, as well as the backbone of the levy."));
            menuVladianYeomen.effectedSkills = new List<SkillObject>()
                      {
                        DefaultSkills.Polearm,
                        DefaultSkills.Crossbow
                      }; //List<SkillObject>
            menuVladianYeomen.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuVladianYeomen.focusToAdd = characterCreationContent.FocusToAdd;
            menuVladianYeomen.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVladianYeomen.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVladianYeomen.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuVladianYeomen.onSelect = new CharacterCreationOnSelect(this.VlandiaYeomanOnConsequence);//CharacterCreationOnSelect
            menuVladianYeomen.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuVladianUrbanBlacksmith = new CMenuOption(new TextObject("{=p2KIhGbE}Urban blacksmith"), new TextObject("{=btsMpRcA}Your family owned a smithy in a city. Your father played an active if minor role in the town council, and also served in the militia."));
            menuVladianUrbanBlacksmith.effectedSkills = new List<SkillObject>()
                      {
                        DefaultSkills.Crafting,
                        DefaultSkills.TwoHanded
                      }; //List<SkillObject>
            menuVladianUrbanBlacksmith.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuVladianUrbanBlacksmith.focusToAdd = characterCreationContent.FocusToAdd;
            menuVladianUrbanBlacksmith.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVladianUrbanBlacksmith.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVladianUrbanBlacksmith.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuVladianUrbanBlacksmith.onSelect = new CharacterCreationOnSelect(this.VlandiaBlacksmithOnConsequence);//CharacterCreationOnSelect
            menuVladianUrbanBlacksmith.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuVladianHunters = new CMenuOption(new TextObject("{=YcnK0Thk}Hunters"), new TextObject("{=yRFSzSDZ}Your family lived in a village, but did not own their own land. Instead, your father supplemented paid jobs with long trips in the woods, hunting and trapping, always keeping a wary eye for the lord's game wardens."));
            menuVladianHunters.effectedSkills = new List<SkillObject>()
                      {
                        DefaultSkills.Scouting,
                        DefaultSkills.Crossbow
                      }; //List<SkillObject>
            menuVladianHunters.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuVladianHunters.focusToAdd = characterCreationContent.FocusToAdd;
            menuVladianHunters.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVladianHunters.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVladianHunters.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuVladianHunters.onSelect = new CharacterCreationOnSelect(this.VlandiaHunterOnConsequence);//CharacterCreationOnSelect
            menuVladianHunters.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuVladianMercenaries = new CMenuOption(new TextObject("{=ipQP6aVi}Mercenaries"), new TextObject("{=yYhX6JQC}Your father joined one of Vlandia's many mercenary companies, composed of men who got such a taste for war in their lord's service that they never took well to peace. Their crossbowmen were much valued across Calradia. Your mother was a camp follower, taking you along in the wake of bloody campaigns."));
            menuVladianMercenaries.effectedSkills = new List<SkillObject>()
                      {
                        DefaultSkills.Roguery,
                        DefaultSkills.Crossbow
                      }; //List<SkillObject>
            menuVladianMercenaries.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuVladianMercenaries.focusToAdd = characterCreationContent.FocusToAdd;
            menuVladianMercenaries.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuVladianMercenaries.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuVladianMercenaries.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuVladianMercenaries.onSelect = new CharacterCreationOnSelect(this.VlandiaMercenaryOnConsequence);//CharacterCreationOnSelect
            menuVladianMercenaries.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            vlandianOptinonsList.Add(menuVladianbaronsRetainers);
            vlandianOptinonsList.Add(menuVladianUrbanMerchants);
            vlandianOptinonsList.Add(menuVladianYeomen);
            vlandianOptinonsList.Add(menuVladianUrbanBlacksmith);
            vlandianOptinonsList.Add(menuVladianHunters);
            vlandianOptinonsList.Add(menuVladianMercenaries);


            RestrictedOptions.Add(new CharacterCreationOnCondition(this.VlandianParentsOnCondition), vlandianOptinonsList);

            #endregion

            // CULTURE EQUALS Sturgian
            #region Sturgian Options
            List<CMenuOption> SturgianOptinonsList = new List<CMenuOption>();

            CMenuOption menuBoyarsCompanions = new CMenuOption(new TextObject("{=mc78FEbA}A boyar's companions"), new TextObject("{=hob3WVkU}Your father was a member of a boyar's druzhina, the 'companions' that make up his retinue. He sat at his lord's table in the great hall, oversaw the boyar's estates, and stood by his side in the center of the shield wall in battle."));
            menuBoyarsCompanions.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.TwoHanded
                  }; //List<SkillObject>
            menuBoyarsCompanions.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuBoyarsCompanions.focusToAdd = characterCreationContent.FocusToAdd;
            menuBoyarsCompanions.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBoyarsCompanions.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBoyarsCompanions.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuBoyarsCompanions.onSelect = new CharacterCreationOnSelect(this.SturgiaBoyarsCompanionOnConsequence);//CharacterCreationOnSelect
            menuBoyarsCompanions.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuSturgianUrbanTraders = new CMenuOption(new TextObject("{=HqzVBfpl}Urban traders"), new TextObject("{=bjVMtW3W}Your family were merchants who lived in one of Sturgia's great river ports, organizing the shipment of the north's bounty of furs, honey and other goods to faraway lands."));
            menuSturgianUrbanTraders.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Tactics
                  }; //List<SkillObject>
            menuSturgianUrbanTraders.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuSturgianUrbanTraders.focusToAdd = characterCreationContent.FocusToAdd;
            menuSturgianUrbanTraders.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSturgianUrbanTraders.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSturgianUrbanTraders.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuSturgianUrbanTraders.onSelect = new CharacterCreationOnSelect(this.SturgiaTraderOnConsequence);//CharacterCreationOnSelect
            menuSturgianUrbanTraders.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuSturgianFreeFarmers = new CMenuOption(new TextObject("{=zrpqSWSh}Free farmers"), new TextObject("{=Mcd3ZyKq}Your family had just enough land to feed themselves and make a small profit. People like them were the pillars of the kingdom's economy, as well as the backbone of the levy."));
            menuSturgianFreeFarmers.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Polearm
                  }; //List<SkillObject>
            menuSturgianFreeFarmers.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuSturgianFreeFarmers.focusToAdd = characterCreationContent.FocusToAdd;
            menuSturgianFreeFarmers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSturgianFreeFarmers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSturgianFreeFarmers.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuSturgianFreeFarmers.onSelect = new CharacterCreationOnSelect(this.SturgiaFreemanOnConsequence);//CharacterCreationOnSelect
            menuSturgianFreeFarmers.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuSturgianUrbanArtisans = new CMenuOption(new TextObject("{=v48N6h1t}Urban artisans"), new TextObject("{=ueCm5y1C}Your family owned their own workshop in a city, making goods from raw materials brought in from the countryside. Your father played an active if minor role in the town council, and also served in the militia."));
            menuSturgianUrbanArtisans.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Crafting,
                    DefaultSkills.OneHanded
                  }; //List<SkillObject>
            menuSturgianUrbanArtisans.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuSturgianUrbanArtisans.focusToAdd = characterCreationContent.FocusToAdd;
            menuSturgianUrbanArtisans.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSturgianUrbanArtisans.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSturgianUrbanArtisans.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuSturgianUrbanArtisans.onSelect = new CharacterCreationOnSelect(this.SturgiaArtisanOnConsequence);//CharacterCreationOnSelect
            menuSturgianUrbanArtisans.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuSturgianHunters = new CMenuOption(new TextObject("{=YcnK0Thk}Hunters"), new TextObject("{=WyZ2UtFF}Your family had no taste for the authority of the boyars. They made their living deep in the woods, slashing and burning fields which they tended for a year or two before moving on. They hunted and trapped fox, hare, ermine, and other fur-bearing animals."));
            menuSturgianHunters.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Scouting,
                    DefaultSkills.Bow
                  }; //List<SkillObject>
            menuSturgianHunters.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuSturgianHunters.focusToAdd = characterCreationContent.FocusToAdd;
            menuSturgianHunters.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSturgianHunters.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSturgianHunters.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuSturgianHunters.onSelect = new CharacterCreationOnSelect(this.SturgiaHunterOnConsequence);//CharacterCreationOnSelect
            menuSturgianHunters.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuSturgianVagabonds = new CMenuOption(new TextObject("{=TPoK3GSj}Vagabonds"), new TextObject("{=2SDWhGmQ}Your family numbered among the poor migrants living in the slums that grow up outside the walls of the river cities, making whatever money they could from a variety of odd jobs. Sometimes they did services for one of the region's many criminal gangs."));
            menuSturgianVagabonds.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuSturgianVagabonds.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuSturgianVagabonds.focusToAdd = characterCreationContent.FocusToAdd;
            menuSturgianVagabonds.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuSturgianVagabonds.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuSturgianVagabonds.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuSturgianVagabonds.onSelect = new CharacterCreationOnSelect(this.SturgiaVagabondOnConsequence);//CharacterCreationOnSelect
            menuSturgianVagabonds.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects


            SturgianOptinonsList.Add(menuBoyarsCompanions);
            SturgianOptinonsList.Add(menuSturgianUrbanTraders);
            SturgianOptinonsList.Add(menuSturgianFreeFarmers);
            SturgianOptinonsList.Add(menuSturgianUrbanArtisans);
            SturgianOptinonsList.Add(menuSturgianHunters);
            SturgianOptinonsList.Add(menuSturgianVagabonds);

            RestrictedOptions.Add(new CharacterCreationOnCondition(this.SturgianParentsOnCondition), SturgianOptinonsList);
            #endregion

            // CULTURE EQUALS Aserai
            #region Aserai Options
            List<CMenuOption> AseraiOptinonsList = new List<CMenuOption>();

            CMenuOption menuKinsfolkofanEmir = new CMenuOption(new TextObject("{=Sw8OxnNr}Kinsfolk of an emir"), new TextObject("{=MFrIHJZM}Your family was from a smaller offshoot of an emir's tribe. Your father's land gave him enough income to afford a horse but he was not quite wealthy enough to buy the armor needed to join the heavier cavalry. He fought as one of the light horsemen for which the desert is famous."));
            menuKinsfolkofanEmir.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuKinsfolkofanEmir.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuKinsfolkofanEmir.focusToAdd = characterCreationContent.FocusToAdd;
            menuKinsfolkofanEmir.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuKinsfolkofanEmir.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuKinsfolkofanEmir.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuKinsfolkofanEmir.onSelect = new CharacterCreationOnSelect(this.AseraiTribesmanOnConsequence);//CharacterCreationOnSelect
            menuKinsfolkofanEmir.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuWarriorSlaves = new CMenuOption(new TextObject("{=ngFVgwDD}Warrior-slaves"), new TextObject("{=GsPC2MgU}Your father was part of one of the slave-bodyguards maintained by the Aserai emirs. He fought by his master's side with tribe's armored cavalry, and was freed - perhaps for an act of valor, or perhaps he paid for his freedom with his share of the spoils of battle. He then married your mother."));
            menuWarriorSlaves.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Polearm
                  }; //List<SkillObject>
            menuWarriorSlaves.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuWarriorSlaves.focusToAdd = characterCreationContent.FocusToAdd;
            menuWarriorSlaves.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuWarriorSlaves.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuWarriorSlaves.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuWarriorSlaves.onSelect = new CharacterCreationOnSelect(this.AseraiWariorSlaveOnConsequence);//CharacterCreationOnSelect
            menuWarriorSlaves.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuAseraiUrbanMerchants = new CMenuOption(new TextObject("{=651FhzdR}Urban merchants"), new TextObject("{=1zXrlaav}Your family were respected traders in an oasis town. They ran caravans across the desert, and were experts in the finer points of negotiating passage through the desert tribes' territories."));
            menuAseraiUrbanMerchants.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuAseraiUrbanMerchants.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuAseraiUrbanMerchants.focusToAdd = characterCreationContent.FocusToAdd;
            menuAseraiUrbanMerchants.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuAseraiUrbanMerchants.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuAseraiUrbanMerchants.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuAseraiUrbanMerchants.onSelect = new CharacterCreationOnSelect(this.AseraiMerchantOnConsequence);//CharacterCreationOnSelect
            menuAseraiUrbanMerchants.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuOasisFarmers = new CMenuOption(new TextObject("{=g31pXuqi}Oasis farmers"), new TextObject("{=5P0KqBAw}Your family tilled the soil in one of the oases of the Nahasa and tended the palm orchards that produced the desert's famous dates. Your father was a member of the main foot levy of his tribe, fighting with his kinsmen under the emir's banner."));
            menuOasisFarmers.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.OneHanded
                  }; //List<SkillObject>
            menuOasisFarmers.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuOasisFarmers.focusToAdd = characterCreationContent.FocusToAdd;
            menuOasisFarmers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuOasisFarmers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuOasisFarmers.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuOasisFarmers.onSelect = new CharacterCreationOnSelect(this.AseraiOasisFarmerOnConsequence);//CharacterCreationOnSelect
            menuOasisFarmers.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuBedouin = new CMenuOption(new TextObject("{=EEedqolz}Bedouin"), new TextObject("{=PKhcPbBX}Your family were part of a nomadic clan, crisscrossing the wastes between wadi beds and wells to feed their herds of goats and camels on the scraggly scrubs of the Nahasa."));
            menuBedouin.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Scouting,
                    DefaultSkills.Bow
                  }; //List<SkillObject>
            menuBedouin.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuBedouin.focusToAdd = characterCreationContent.FocusToAdd;
            menuBedouin.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBedouin.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBedouin.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuBedouin.onSelect = new CharacterCreationOnSelect(this.AseraiBedouinOnConsequence);//CharacterCreationOnSelect
            menuBedouin.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuAseraiBackAlleyThugs = new CMenuOption(new TextObject("{=tRIrbTvv}Urban back-alley thugs"), new TextObject("{=6bUSbsKC}Your father worked for a fitiwi, one of the strongmen who keep order in the poorer quarters of the oasis towns. He resolved disputes over land, dice and insults, imposing his authority with the fitiwi's traditional staff."));
            menuAseraiBackAlleyThugs.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.Polearm
                  }; //List<SkillObject>
            menuAseraiBackAlleyThugs.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuAseraiBackAlleyThugs.focusToAdd = characterCreationContent.FocusToAdd;
            menuAseraiBackAlleyThugs.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuAseraiBackAlleyThugs.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuAseraiBackAlleyThugs.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuAseraiBackAlleyThugs.onSelect = new CharacterCreationOnSelect(this.AseraiBackAlleyThugOnConsequence);//CharacterCreationOnSelect
            menuAseraiBackAlleyThugs.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects


            AseraiOptinonsList.Add(menuKinsfolkofanEmir);
            AseraiOptinonsList.Add(menuWarriorSlaves);
            AseraiOptinonsList.Add(menuAseraiUrbanMerchants);
            AseraiOptinonsList.Add(menuOasisFarmers);
            AseraiOptinonsList.Add(menuBedouin);
            AseraiOptinonsList.Add(menuAseraiBackAlleyThugs);

            RestrictedOptions.Add(new CharacterCreationOnCondition(this.AseraiParentsOnCondition), AseraiOptinonsList);
            #endregion

            // CULTURE EQUALS Battania
            #region Battania Options
            List<CMenuOption> BattaniaOptinonsList = new List<CMenuOption>();

            CMenuOption menuchieftainsHearthguard = new CMenuOption(new TextObject("{=GeNKQlHR}Members of the chieftain's hearthguard"), new TextObject("{=LpH8SYFL}Your family were the trusted kinfolk of a Battanian chieftain, and sat at his table in his great hall. Your father assisted his chief in running the affairs of the clan and trained with the traditional weapons of the Battanian elite, the two-handed sword or falx and the bow."));
            menuchieftainsHearthguard.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.TwoHanded,
                    DefaultSkills.Bow
                  }; //List<SkillObject>
            menuchieftainsHearthguard.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuchieftainsHearthguard.focusToAdd = characterCreationContent.FocusToAdd;
            menuchieftainsHearthguard.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuchieftainsHearthguard.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuchieftainsHearthguard.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuchieftainsHearthguard.onSelect = new CharacterCreationOnSelect(this.BattaniaChieftainsHearthguardOnConsequence);//CharacterCreationOnSelect
            menuchieftainsHearthguard.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuHealers = new CMenuOption(new TextObject("{=AeBzTj6w}Healers"), new TextObject("{=j6py5Rv5}Your parents were healers who gathered herbs and treated the sick. As a living reservoir of Battanian tradition, they were also asked to adjudicate many disputes between the clans."));
            menuHealers.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Medicine,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuHealers.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuHealers.focusToAdd = characterCreationContent.FocusToAdd;
            menuHealers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuHealers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuHealers.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuHealers.onSelect = new CharacterCreationOnSelect(this.BattaniaHealerOnConsequence);//CharacterCreationOnSelect
            menuHealers.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuTribespeople = new CMenuOption(new TextObject("{=tGEStbxb}Tribespeople"), new TextObject("{=WchH8bS2}Your family were middle-ranking members of a Battanian clan, who tilled their own land. Your father fought with the kern, the main body of his people's warriors, joining in the screaming charges for which the Battanians were famous."));
            menuTribespeople.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Athletics,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuTribespeople.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuTribespeople.focusToAdd = characterCreationContent.FocusToAdd;
            menuTribespeople.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuTribespeople.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuTribespeople.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuTribespeople.onSelect = new CharacterCreationOnSelect(this.BattaniaTribesmanOnConsequence);//CharacterCreationOnSelect
            menuTribespeople.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuBattaniaSmiths = new CMenuOption(new TextObject("{=BCU6RezA}Smiths"), new TextObject("{=kg9YtrOg}Your family were smiths, a revered profession among the Battanians. They crafted everything from fine filigree jewelry in geometric designs to the well-balanced longswords favored by the Battanian aristocracy."));
            menuBattaniaSmiths.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Crafting,
                    DefaultSkills.TwoHanded
                  }; //List<SkillObject>
            menuBattaniaSmiths.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuBattaniaSmiths.focusToAdd = characterCreationContent.FocusToAdd;
            menuBattaniaSmiths.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBattaniaSmiths.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBattaniaSmiths.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuBattaniaSmiths.onSelect = new CharacterCreationOnSelect(this.BattaniaSmithOnConsequence);//CharacterCreationOnSelect
            menuBattaniaSmiths.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuBattaniaForesters = new CMenuOption(new TextObject("{=7eWmU2mF}Foresters"), new TextObject("{=7jBroUUQ}Your family had little land of their own, so they earned their living from the woods, hunting and trapping. They taught you from an early age that skills like finding game trails and killing an animal with one shot could make the difference between eating and starvation."));
            menuBattaniaForesters.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Scouting,
                    DefaultSkills.Tactics
                  }; //List<SkillObject>
            menuBattaniaForesters.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuBattaniaForesters.focusToAdd = characterCreationContent.FocusToAdd;
            menuBattaniaForesters.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBattaniaForesters.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBattaniaForesters.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuBattaniaForesters.onSelect = new CharacterCreationOnSelect(this.BattaniaWoodsmanOnConsequence);//CharacterCreationOnSelect
            menuBattaniaForesters.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuBards = new CMenuOption(new TextObject("{=SpJqhEEh}Bards"), new TextObject("{=aVzcyhhy}Your father was a bard, drifting from chieftain's hall to chieftain's hall making his living singing the praises of one Battanian aristocrat and mocking his enemies, then going to his enemy's hall and doing the reverse. You learned from him that a clever tongue could spare you  from a life toiling in the fields, if you kept your wits about you."));
            menuBards.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Roguery,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuBards.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuBards.focusToAdd = characterCreationContent.FocusToAdd;
            menuBards.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuBards.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuBards.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuBards.onSelect = new CharacterCreationOnSelect(this.BattaniaBardOnConsequence);//CharacterCreationOnSelect
            menuBards.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects



            BattaniaOptinonsList.Add(menuchieftainsHearthguard);
            BattaniaOptinonsList.Add(menuHealers);
            BattaniaOptinonsList.Add(menuTribespeople);
            BattaniaOptinonsList.Add(menuBattaniaSmiths);
            BattaniaOptinonsList.Add(menuBattaniaForesters);
            BattaniaOptinonsList.Add(menuBards);

            RestrictedOptions.Add(new CharacterCreationOnCondition(this.BattanianParentsOnCondition), BattaniaOptinonsList);
            #endregion

            // CULTURE EQUALS Khuzait
            #region Khuzait Options
            List<CMenuOption> KhuzaitOptinonsList = new List<CMenuOption>();

            CMenuOption menuNoyansKinsfolk = new CMenuOption(new TextObject("{=FVaRDe2a}A noyan's kinsfolk"), new TextObject("{=jAs3kDXh}Your family were the trusted kinsfolk of a Khuzait noyan, and shared his meals in the chieftain's yurt. Your father assisted his chief in running the affairs of the clan and fought in the core of armored lancers in the center of the Khuzait battle line."));
            menuNoyansKinsfolk.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Riding,
                    DefaultSkills.Polearm
                  }; //List<SkillObject>
            menuNoyansKinsfolk.effectedAttribute = DefaultCharacterAttributes.Endurance; //CharacterAttribute
            menuNoyansKinsfolk.focusToAdd = characterCreationContent.FocusToAdd;
            menuNoyansKinsfolk.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuNoyansKinsfolk.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuNoyansKinsfolk.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuNoyansKinsfolk.onSelect = new CharacterCreationOnSelect(this.KhuzaitNoyansKinsmanOnConsequence);//CharacterCreationOnSelect
            menuNoyansKinsfolk.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuKhuzaitMerchants = new CMenuOption(new TextObject("{=TkgLEDRM}Merchants"), new TextObject("{=qPg3IDiq}Your family came from one of the merchant clans that dominated the cities in eastern Calradia before the Khuzait conquest. They adjusted quickly to their new masters, keeping the caravan routes running and ensuring that the tariff revenues that once went into imperial coffers now flowed to the khanate."));
            menuKhuzaitMerchants.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Trade,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuKhuzaitMerchants.effectedAttribute = DefaultCharacterAttributes.Social; //CharacterAttribute
            menuKhuzaitMerchants.focusToAdd = characterCreationContent.FocusToAdd;
            menuKhuzaitMerchants.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuKhuzaitMerchants.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuKhuzaitMerchants.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuKhuzaitMerchants.onSelect = new CharacterCreationOnSelect(this.KhuzaitMerchantOnConsequence);//CharacterCreationOnSelect
            menuKhuzaitMerchants.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuKhuzaitTribespeople = new CMenuOption(new TextObject("{=tGEStbxb}Tribespeople"), new TextObject("{=URgZ4ai4}Your family were middle-ranking members of one of the Khuzait clans. He had some  herds of his own, but was not rich. When the Khuzait horde was summoned to battle, he fought with the horse archers, shooting and wheeling and wearing down the enemy before the lancers delivered the final punch."));
            menuKhuzaitTribespeople.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Bow,
                    DefaultSkills.Riding
                  }; //List<SkillObject>
            menuKhuzaitTribespeople.effectedAttribute = DefaultCharacterAttributes.Control; //CharacterAttribute
            menuKhuzaitTribespeople.focusToAdd = characterCreationContent.FocusToAdd;
            menuKhuzaitTribespeople.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuKhuzaitTribespeople.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuKhuzaitTribespeople.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuKhuzaitTribespeople.onSelect = new CharacterCreationOnSelect(this.KhuzaitTribesmanOnConsequence);//CharacterCreationOnSelect
            menuKhuzaitTribespeople.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuKhuzaitFarmers = new CMenuOption(new TextObject("{=gQ2tAvCz}Farmers"), new TextObject("{=5QSGoRFj}Your family tilled one of the small patches of arable land in the steppes for generations. When the Khuzaits came, they ceased paying taxes to the emperor and providing conscripts for his army, and served the khan instead."));
            menuKhuzaitFarmers.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Polearm,
                    DefaultSkills.Throwing
                  }; //List<SkillObject>
            menuKhuzaitFarmers.effectedAttribute = DefaultCharacterAttributes.Vigor; //CharacterAttribute
            menuKhuzaitFarmers.focusToAdd = characterCreationContent.FocusToAdd;
            menuKhuzaitFarmers.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuKhuzaitFarmers.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuKhuzaitFarmers.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuKhuzaitFarmers.onSelect = new CharacterCreationOnSelect(this.KhuzaitFarmerOnConsequence);//CharacterCreationOnSelect
            menuKhuzaitFarmers.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuKhuzaitShamans = new CMenuOption(new TextObject("{=vfhVveLW}Shamans"), new TextObject("{=WOKNhaG2}Your family were guardians of the sacred traditions of the Khuzaits, channelling the spirits of the wilderness and of the ancestors. They tended the sick and dispensed wisdom, resolving disputes and providing practical advice."));
            menuKhuzaitShamans.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Medicine,
                    DefaultSkills.Charm
                  }; //List<SkillObject>
            menuKhuzaitShamans.effectedAttribute = DefaultCharacterAttributes.Intelligence; //CharacterAttribute
            menuKhuzaitShamans.focusToAdd = characterCreationContent.FocusToAdd;
            menuKhuzaitShamans.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuKhuzaitShamans.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuKhuzaitShamans.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuKhuzaitShamans.onSelect = new CharacterCreationOnSelect(this.KhuzaitShamanOnConsequence);//CharacterCreationOnSelect
            menuKhuzaitShamans.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects

            CMenuOption menuKhuzaitNomads = new CMenuOption(new TextObject("{=Xqba1Obq}Nomads"), new TextObject("{=9aoQYpZs}Your family's clan never pledged its loyalty to the khan and never settled down, preferring to live out in the deep steppe away from his authority. They remain some of the finest trackers and scouts in the grasslands, as the ability to spot an enemy coming and move quickly is often all that protects their herds from their neighbors' predations."));
            menuKhuzaitNomads.effectedSkills = new List<SkillObject>()
                  {
                    DefaultSkills.Scouting,
                    DefaultSkills.Riding
                  }; //List<SkillObject>
            menuKhuzaitNomads.effectedAttribute = DefaultCharacterAttributes.Cunning; //CharacterAttribute
            menuKhuzaitNomads.focusToAdd = characterCreationContent.FocusToAdd;
            menuKhuzaitNomads.skillLevelToAdd = characterCreationContent.SkillLevelToAdd;
            menuKhuzaitNomads.attributeLevelToAdd = characterCreationContent.AttributeLevelToAdd;
            menuKhuzaitNomads.optionCondition = (CharacterCreationOnCondition)null;//CharacterCreationOnCondition
            menuKhuzaitNomads.onSelect = new CharacterCreationOnSelect(this.KhuzaitNomadOnConsequence);//CharacterCreationOnSelect
            menuKhuzaitNomads.onApply = new CharacterCreationApplyFinalEffects(this.FinalizeParents);//CharacterCreationApplyFinalEffects



            KhuzaitOptinonsList.Add(menuNoyansKinsfolk);
            KhuzaitOptinonsList.Add(menuKhuzaitMerchants);
            KhuzaitOptinonsList.Add(menuKhuzaitTribespeople);
            KhuzaitOptinonsList.Add(menuKhuzaitFarmers);
            KhuzaitOptinonsList.Add(menuKhuzaitShamans);
            KhuzaitOptinonsList.Add(menuKhuzaitNomads);

            RestrictedOptions.Add(new CharacterCreationOnCondition(this.KhuzaitParentsOnCondition), KhuzaitOptinonsList);
            #endregion

            //characterCreation.AddNewMenu(menu);
        }


        protected void ParentsOnInit(CharacterCreation characterCreation)
        {
            KaosesStoryModeCharacterCreationContent characterCreationContent = CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation;
            //CharacterCreationMenuFramework.SubModule.CharacterCreation
            characterCreation.IsPlayerAlone = false;
            characterCreation.HasSecondaryCharacter = false;
            characterCreationContent.ClearMountEntity(characterCreation);
            characterCreation.ClearFaceGenPrefab();
            if (characterCreationContent.PlayerBodyProperties != CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1))
            {
                characterCreationContent.PlayerBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
                BodyProperties motherBodyProperties = characterCreationContent.PlayerBodyProperties;
                BodyProperties fatherBodyProperties = characterCreationContent.PlayerBodyProperties;
                FaceGen.GenerateParentKey(characterCreationContent.PlayerBodyProperties, CharacterObject.PlayerCharacter.Race, ref motherBodyProperties, ref fatherBodyProperties);
                motherBodyProperties = new BodyProperties(new DynamicBodyProperties(33f, 0.3f, 0.2f), motherBodyProperties.StaticProperties);
                fatherBodyProperties = new BodyProperties(new DynamicBodyProperties(33f, 0.5f, 0.5f), fatherBodyProperties.StaticProperties);
                characterCreationContent.MotherFacegenCharacter = new FaceGenChar(motherBodyProperties, CharacterObject.PlayerCharacter.Race, new Equipment(), true, "anim_mother_1");
                characterCreationContent.FatherFacegenCharacter = new FaceGenChar(fatherBodyProperties, CharacterObject.PlayerCharacter.Race, new Equipment(), false, "anim_father_1");
            }
            characterCreation.ChangeFaceGenChars(new List<FaceGenChar>()
      {
        characterCreationContent.MotherFacegenCharacter,
        characterCreationContent.FatherFacegenCharacter
      });
            characterCreationContent.ChangeParentsOutfit(characterCreation);
            characterCreationContent.ChangeParentsAnimation(characterCreation);
        }

        #region Parent Culture Conditions
        protected bool EmpireParentsOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "empire";

        protected bool VlandianParentsOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "vlandia";

        protected bool SturgianParentsOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "sturgia";

        protected bool AseraiParentsOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "aserai";

        protected bool BattanianParentsOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "battania";

        protected bool KhuzaitParentsOnCondition() => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.GetSelectedCulture().StringId == "khuzait";
        #endregion

        protected void FinalizeParents(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.FinalizeParents();

        #region Empire on consequence
        protected void EmpireLandlordsRetainerOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 1, KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer);
        protected void EmpireMerchantOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 2, KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant);
        protected void EmpireArtisanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 4, KaosesStoryModeCharacterCreationContent.OccupationTypes.Artisan);
        protected void EmpireWoodsmanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 5, KaosesStoryModeCharacterCreationContent.OccupationTypes.Hunter);
        protected void EmpireVagabondOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 6, KaosesStoryModeCharacterCreationContent.OccupationTypes.Vagabond);
        protected void EmpireFreeholderOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 3, KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer);


        #endregion

        #region Vladian on consequence
        protected void VlandiaBaronsRetainerOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 1, KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer);
        protected void VlandiaMerchantOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 2, KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant);
        protected void VlandiaYeomanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 3, KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer);
        protected void VlandiaBlacksmithOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 4, KaosesStoryModeCharacterCreationContent.OccupationTypes.Artisan);
        protected void VlandiaHunterOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 5, KaosesStoryModeCharacterCreationContent.OccupationTypes.Hunter);
        protected void VlandiaMercenaryOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 6, KaosesStoryModeCharacterCreationContent.OccupationTypes.Mercenary);
        #endregion

        #region Sturgian on consequence
        protected void SturgiaBoyarsCompanionOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 1, KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer);
        protected void SturgiaTraderOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 2, KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant);
        protected void SturgiaFreemanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 3, KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer);
        protected void SturgiaArtisanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 4, KaosesStoryModeCharacterCreationContent.OccupationTypes.Artisan);
        protected void SturgiaHunterOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 5, KaosesStoryModeCharacterCreationContent.OccupationTypes.Hunter);
        protected void SturgiaVagabondOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 6, KaosesStoryModeCharacterCreationContent.OccupationTypes.Vagabond);
        #endregion

        #region Aserai on consequence
        protected void AseraiTribesmanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 1, KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer);
        protected void AseraiWariorSlaveOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 2, KaosesStoryModeCharacterCreationContent.OccupationTypes.Mercenary);
        protected void AseraiMerchantOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 3, KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant);
        protected void AseraiOasisFarmerOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 4, KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer);
        protected void AseraiBedouinOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 5, KaosesStoryModeCharacterCreationContent.OccupationTypes.Herder);
        protected void AseraiBackAlleyThugOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 6, KaosesStoryModeCharacterCreationContent.OccupationTypes.Artisan);
        #endregion

        #region Khuzait on consequence
        protected void KhuzaitNoyansKinsmanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 1, KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer);
        protected void KhuzaitMerchantOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 2, KaosesStoryModeCharacterCreationContent.OccupationTypes.Merchant);
        protected void KhuzaitTribesmanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 3, KaosesStoryModeCharacterCreationContent.OccupationTypes.Herder);
        protected void KhuzaitFarmerOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 4, KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer);
        protected void KhuzaitShamanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 5, KaosesStoryModeCharacterCreationContent.OccupationTypes.Healer);
        protected void KhuzaitNomadOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 6, KaosesStoryModeCharacterCreationContent.OccupationTypes.Herder);
        #endregion

        #region Battania on consequence
        protected void BattaniaChieftainsHearthguardOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 1, KaosesStoryModeCharacterCreationContent.OccupationTypes.Retainer);
        protected void BattaniaHealerOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 2, KaosesStoryModeCharacterCreationContent.OccupationTypes.Healer);
        protected void BattaniaTribesmanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 3, KaosesStoryModeCharacterCreationContent.OccupationTypes.Farmer);
        protected void BattaniaSmithOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 4, KaosesStoryModeCharacterCreationContent.OccupationTypes.Artisan);
        protected void BattaniaWoodsmanOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 5, KaosesStoryModeCharacterCreationContent.OccupationTypes.Hunter);
        protected void BattaniaBardOnConsequence(CharacterCreation characterCreation) => CharacterCreationMenuFramework.Objects.Factory.KaosesCharacterCreation.SetParentAndOccupationType(characterCreation, 6, KaosesStoryModeCharacterCreationContent.OccupationTypes.Bard);

        #endregion


    }
}
