using MCM.Abstractions;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.Common;
using System;
using System.Collections.Generic;
using TaleWorlds.Localization;

//using MCM.Abstractions.Settings.Base.PerSave;


namespace CharacterCreationMenuFramework.Settings
{
    //public class Settings : AttributePerSaveSettings<Settings>, ISettingsProviderInterface
    public class Config : AttributeGlobalSettings<Config>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Config()
        {
            PropertyChanged += MCMSettings_PropertyChanged;
        }


        #region ModSettingsStandard
        public override string Id => SubModule.ModuleId;
        public override string FolderName => SubModule.ModuleId;
        public string ModName => "Kaoses CCMF";
        public override string FormatType => "json";
        #region Translatable DisplayName 
        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        public TextObject versionTextObj = new TextObject(typeof(Config).Assembly.GetName().Version?.ToString(3) ?? "");
        public override string DisplayName => new TextObject("{=CharacterCreationMenuFrameworkDisplayName}" + ModName + " " + versionTextObj.ToString())!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the null ability of reference types.
        #endregion
        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        #region Debug

        [SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=debug_desc}Displays mod developer debug information and logs them to the file")]
        [SettingPropertyGroup("Debug", GroupOrder = 1)]
#if DEBUG
        public bool Debug { get; set; } = true;
#else
        public bool Debug { get; set; } = false;
#endif
        [SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
#if DEBUG
        public bool LogToFile { get; set; } = true;
#else
        public bool LogToFile { get; set; } = false;
#endif


        [SettingPropertyBool("{=debugharmony}Debug Harmony", RequireRestart = false, HintText = "{=debugharmony_desc}Enable/Disable harmony's debuging logs")]
        [SettingPropertyGroup("Debug", GroupOrder = 2)]
#if DEBUG
        public bool IsHarmonyDebug { get; set; } = true;
#else
        public bool IsHarmonyDebug { get; set; } = false;
#endif


        #endregion //~Debug


        ///~ Mod Specific settings 
        #region Mod Specific settings


        [SettingPropertyBool("{=CulturedStart52}Skip TW Logo", Order = 0, RequireRestart = false, HintText = "{=CulturedStart53}Skip the TaleWorlds logo. Enabled by default.")]
        [SettingPropertyGroup("{=CulturedStart51}Debug", GroupOrder = 0)]
        public bool ShouldSkipTWLogo { get; set; } = true;

        [SettingPropertyBool("{=CulturedStart54}Skip Campaign Intro", Order = 1, RequireRestart = false, HintText = "{=CulturedStart55}Skip the campaign intro. Enabled by default.")]
        [SettingPropertyGroup("{=CulturedStart51}Debug", GroupOrder = 0)]
        public bool ShouldSkipCampaignIntro { get; set; } = true;

        [SettingPropertyBool("{=CulturedStart54}Randomise Culture", Order = 1, RequireRestart = false, HintText = "{=CulturedStart55}Randomise Culture. Disabled by default.")]
        [SettingPropertyGroup("{=CulturedStart51}Debug", GroupOrder = 0)]
        public bool cultureRandomise { get; set; } = true;



        [SettingPropertyDropdown("{=CulturedStart56}Skip Character Creation Menus", Order = 2, RequireRestart = false, HintText = "{=CulturedStart57}Skip character creation menus and start with a random culture and skipped options set to default. Default is None.")]
        [SettingPropertyGroup("{=CulturedStart51}Debug", GroupOrder = 0)]
        public Dropdown<string> MenusToSkip { get; set; } = new Dropdown<string>(new string[] {
            "{=CulturedStart58}None",
            "{=CulturedStart59}Base",
            "{=CulturedStart60}All"
        }, 0);


        #endregion

        //~ Presets
        #region Presets
        public override IEnumerable<ISettingsPreset> GetBuiltInPresets()
        {
            foreach (var preset in base.GetBuiltInPresets())
            {
                yield return preset;
            }

            yield return new MemorySettingsPreset(Id, "native all off", "Native All Off", () => new Config
            {

            });


            yield return new MemorySettingsPreset(Id, "native all on", "Native All On", () => new Config
            {
                //TownFoodBonus = 4.0f,
                //SettlementFoodBonusEnabled = true,
                //SettlementProsperityFoodMalusDivisor = 100
            });
        }
        #endregion


        private void MCMSettings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Debug))
            {
                Debug = false;
                LogToFile = false;
            }
        }


    }
}
