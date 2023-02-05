using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.Settings;
using CharacterCreationMenuFramework.StartObj;
using KaosesCommon.Objects;
using KaosesCommon.Utils;
using System.Reflection;
using TaleWorlds.CampaignSystem.CharacterCreationContent;

namespace CharacterCreationMenuFramework.Objects
{
    /// <summary>
    /// CharacterCreationMenuFramework Factory Object
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Variable to hold the MCM settings object
        /// </summary>
        private static Config? _settings = null;

        private static MenuManager? _MenuManager = null;

        public static KaosesStoryModeCharacterCreationContent KaosesCharacterCreation;

        public static CharacterCreationState _CharacterCreationState;



        /// <summary>
        /// Bool indicates if MCM is a loaded mod
        /// </summary>
        public static bool MCMModuleLoaded { get; set; } = false;

        private static InfoMgr? _im = null;

        public static InfoMgr IM
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
        }

        /// <summary>
        /// MCM Settings Object Instance
        /// </summary>
        public static Config Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Config.Instance;
                    if (_settings is null)
                    {
                        Factory.IM.ShowMessageBox("Kaoses CCMF Failed to load MCM config provider", "Kaoses CCMF MCM Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        /// <summary>
        /// MenuManager Object Instance
        /// </summary>
        public static MenuManager menuManager
        {
            get
            {
                if (_MenuManager == null)
                {
                    _MenuManager = new MenuManager();
                    if (_MenuManager is null)
                    {
                        IM.ShowMessageBox("Kaoses Custom Start Failed to create MenuManager", "Kaoses Custom Start MenuManager Error");
                    }
                }
                return _MenuManager;
            }
            /*            set
                        {
                            _MenuManager = value;
                        }*/
        }

        /// <summary>
        /// Mod version
        /// </summary>
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Unused mod config file path
        /// </summary>
        private static string ConfigFilePath
        {

            get
            {
                return @"..\\..\\Modules\\" + SubModule.ModuleId + "\\config.json";
            }
            //set {  = value; }

        }

    }
}
