using KaosesCommon.Utils;
using CharacterCreationMenuFramework.Interfaces;
using CharacterCreationMenuFramework.NativeMenus;
using CharacterCreationMenuFramework.NewFolder;
using CharacterCreationMenuFramework.Objects;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using static CharacterCreationMenuFramework.Enums;

namespace CharacterCreationMenuFramework.StartObj
{
    public class MenuManager
    {
        public bool IsStoryMode = false;

        /// <summary>
        /// List of all registered custom menu objects
        /// </summary>
        protected List<ICustomMenu> subObjectsList = new List<ICustomMenu>();
        /// <summary>
        /// List of used menus id's as they are added to final menu Dictionary
        /// </summary>
        protected List<string> usedMenuIds = new List<string>();
        /// <summary>
        /// The organised Distionary list of custom menu objects
        /// </summary>
        protected Dictionary<string, ICustomMenu> finalMenuList = new Dictionary<string, ICustomMenu>();
        /// <summary>
        /// The converted native menu objects
        /// </summary>
        protected Dictionary<string, ICustomMenu> nativeMenusList = new Dictionary<string, ICustomMenu>();
        /// <summary>
        /// ????
        /// </summary>
        protected List<CMenuOption> optionsList = new List<CMenuOption>();
        /// <summary>
        /// ???
        /// </summary>
        protected Dictionary<string, CMenuOption> replacementOptions = new Dictionary<string, CMenuOption>();
        /// <summary>
        /// Dictionary of all the start menus
        /// </summary>
        protected Dictionary<string, ICustomMenu> startMenus = new Dictionary<string, ICustomMenu>();
        /// <summary>
        /// Dictionary of all the start end
        /// </summary>
        protected Dictionary<string, ICustomMenu> endMenus = new Dictionary<string, ICustomMenu>();
        /// <summary>
        /// Dictionary of all the default menus
        /// </summary>
        protected Dictionary<string, ICustomMenu> defaultMenus = new Dictionary<string, ICustomMenu>();
        /// <summary>
        /// Dictionary of all the replacement menus
        /// </summary>
        protected Dictionary<string, ICustomMenu> replacementmenusList = new Dictionary<string, ICustomMenu>();
        /// <summary>
        /// List of all menu ids that are to be removed from building, not addeed to the finalMenu dictionary list
        /// </summary>
        protected List<string> removedMenus = new List<string>();
        /// <summary>
        /// Dictionary of all the menus that want to be added before another menu
        /// </summary>
        protected Dictionary<string, List<string>> beforeMenus = new Dictionary<string, List<string>>();
        /// <summary>
        /// Dictionary of all the menus that want to be added after another menu
        /// </summary>
        protected Dictionary<string, List<string>> afterMenus = new Dictionary<string, List<string>>();

        /// <summary>
        /// Variable to hold a reference to the CharacterCreation CharacterCreation object
        /// </summary>
        public CharacterCreation CharacterCreation;

        /// <summary>
        /// Constructor
        /// </summary>
        public MenuManager()
        {

        }

        /// <summary>
        /// Register a menu Id for removal from the build list.
        /// </summary>
        /// <param name="menuId">string menu Id</param>
        public void RegisterMenuToRemove(string menuId)
        {
            if (!removedMenus.Contains(menuId))
            {
                removedMenus.Add(menuId);
            }
        }
        /// <summary>
        /// Register a unique ICustomMenu object to be built.
        /// </summary>
        /// <param name="menuObject">ICustomMenu menuObject</param>
        public void RegisterMenuObject(ICustomMenu menuObject)
        {
            if (!subObjectsList.Contains(menuObject))
            {
                subObjectsList.Add(menuObject);
            }
        }
        /// <summary>
        /// ?????
        /// </summary>
        /// <param name="id"></param>
        /// <param name="menuOption"></param>
        protected void ReplaceOptions(string id, CMenuOption menuOption)
        {
            replacementOptions.Add(id, menuOption);
        }
        /// <summary>
        /// Initialise native menus and calls Initialise method on all registered objects
        /// </summary>
        /// <param name="characterCreation"></param>
        /// <param name="characterCreationContent"></param>
        public void InitialiseMenus(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            #region Native Menu Initialised
            FamilyMenu Family = new FamilyMenu();
            Family.Initialise(characterCreation, characterCreationContent);
            nativeMenusList.Add(Family.Id, Family);

            Childhood childhood = new Childhood();
            childhood.Initialise(characterCreation, characterCreationContent);
            nativeMenusList.Add(childhood.Id, childhood);

            Education education = new Education();
            education.Initialise(characterCreation, characterCreationContent);
            nativeMenusList.Add(education.Id, education);

            Youth youth = new Youth();
            youth.Initialise(characterCreation, characterCreationContent);
            nativeMenusList.Add(youth.Id, youth);

            Adulthood adulthood = new Adulthood();
            adulthood.Initialise(characterCreation, characterCreationContent);
            nativeMenusList.Add(adulthood.Id, adulthood);

            if (IsStoryMode)
            {
                Background escape = new Background();
                escape.Initialise(characterCreation, characterCreationContent);
                nativeMenusList.Add(escape.Id, escape);

            }

            if (!IsStoryMode)
            {
                AgeSelection ageSelection = new AgeSelection();
                ageSelection.Initialise(characterCreation, characterCreationContent);
                nativeMenusList.Add(ageSelection.Id, ageSelection);
            }

            #endregion

            foreach (ICustomMenu menu in subObjectsList)
            {
                menu.Initialise(characterCreation, characterCreationContent);
                if (menu.OperationMode == menuOperationMode.Add)
                {
                    if (menu.OperationPosition == Operationposition.BeforeNative)
                    {
                        AddToStartMenu(menu.Id, menu);
                    }
                    if (menu.OperationPosition == Operationposition.AfterNative)
                    {
                        AddToEndMenu(menu.Id, menu);
                    }
                    if (menu.OperationPosition == Operationposition.Default)
                    {
                        AddToDefaultMenu(menu.Id, menu);
                    }

                    if (menu.OperationPosition == Operationposition.Before)
                    {
                        AddBeforeMenu(menu.OperationmenuId, menu.Id);
                    }
                    if (menu.OperationPosition == Operationposition.After)
                    {
                        AddAfterMenu(menu.OperationmenuId, menu.Id);
                    }
                }
                if (menu.OperationMode == menuOperationMode.Replace)
                {
                    AddReplaceMenu(menu.OperationmenuId, menu);
                }

            }
            OrganiseMenusList();
        }
        /// <summary>
        /// Private method add menu to Start menus list so they get built before native menus
        /// </summary>
        /// <param name="menuId">string menuId</param>
        /// <param name="menu">ICustomMenu menuObject</param>
        private void AddToStartMenu(string menuId, ICustomMenu menu)
        {
            if (startMenus.ContainsKey(menuId))
            {
                startMenus[menuId] = menu;
            }
            else
            {
                startMenus.Add(menuId, menu);
            }
        }
        /// <summary>
        /// Private method add menu to End menus list so they get built after native menus
        /// </summary>
        /// <param name="menuId">string menuId</param>
        /// <param name="menu">ICustomMenu menuObject</param>
        private void AddToEndMenu(string menuId, ICustomMenu menu)
        {
            if (endMenus.ContainsKey(menuId))
            {
                endMenus[menuId] = menu;
            }
            else
            {
                endMenus.Add(menuId, menu);
            }
        }
        /// <summary>
        /// Private method add menu to Default menus list so they get built after all other menus. 
        /// This allows for placement before or after other mod menus as well as menu replacements
        /// </summary>
        /// <param name="menuId">string menuId</param>
        /// <param name="menu">ICustomMenu menuObject</param>
        private void AddToDefaultMenu(string menuId, ICustomMenu menu)
        {
            if (defaultMenus.ContainsKey(menuId))
            {
                defaultMenus[menuId] = menu;
            }
            else
            {
                defaultMenus.Add(menuId, menu);
            }
        }
        /// <summary>
        /// Private method add menu to Replacement menus list so they can be obtained during menu building and substituted for original menu
        /// </summary>
        /// <param name="menuId">string menuId</param>
        /// <param name="menu">ICustomMenu menuObject</param>
        private void AddReplaceMenu(string menuId, ICustomMenu menu)
        {
            if (replacementmenusList.ContainsKey(menuId))
            {
                replacementmenusList[menuId] = menu;
            }
            else
            {
                replacementmenusList.Add(menuId, menu);
            }
        }
        /// <summary>
        /// Private method add menu Id to before List and place in Dictionary.
        /// </summary>
        /// <param name="beforeMenuId">string menuId the menu comes before</param>
        /// <param name="menuId">string menus Id</param>
        private void AddBeforeMenu(string beforeMenuId, string menuId)
        {
            List<string> menuIdList = new List<string>();
            if (beforeMenus.ContainsKey(beforeMenuId))
            {
                beforeMenus.TryGetValue(beforeMenuId, out menuIdList);
            }
            menuIdList.Add(menuId);
            beforeMenus.Add(beforeMenuId, menuIdList);
        }
        /// <summary>
        /// Private method add menu Id to after List and place in Dictionary
        /// </summary>
        /// <param name="afterMenuId">string menuId the menu comes after</param>
        /// <param name="menuId">string menus Id</param>
        private void AddAfterMenu(string afterMenuId, string menuId)
        {
            List<string> menuIdList = new List<string>();
            if (afterMenus.ContainsKey(afterMenuId))
            {
                afterMenus.TryGetValue(afterMenuId, out menuIdList);
            }
            menuIdList.Add(menuId);
            afterMenus.Add(afterMenuId, menuIdList);
        }
        /// <summary>
        /// Private method to organise the systems menus order, deals with removal , replacement, before and after checks
        /// </summary>
        private void OrganiseMenusList()
        {
            loopMenusAddToList(startMenus);
            BuildNativeMenusFromList();
            loopMenusAddToList(endMenus);
            loopMenusAddToList(defaultMenus);

            //tmpMenusList = tMenuList;

        }

        /// <summary>
        /// Private method to build the Native menus
        /// </summary>
        /// <param name="tmpList"> referenced temp menu id list</param>
        /// <param name="tmpMenuList">referenced temp menu id to menu object dictionary</param>
        private void BuildNativeMenusFromList()
        {
            foreach (KeyValuePair<string, ICustomMenu> pair in nativeMenusList)
            {
                string nativeMenuId = pair.Key;
                ICustomMenu menuObject = pair.Value;
                if (!removedMenus.Contains(nativeMenuId))
                {
                    HandleBeforeMenus(nativeMenuId);
                    finalMenuList.Add(nativeMenuId, menuObject);
                    HandleAfterMenus(nativeMenuId);
                }
            }
        }
        /// <summary>
        /// Loop over the specified menu list, and get its before and after menus as well as adding it to the menu list. 
        /// Also checks if the menu Id is in the to be replaced list and if so replaces the menu with the new replacement ersion
        /// </summary>
        /// <param name="menusList">Dictionary string, ICustomMenu</param>
        /// <param name="tmpList"> referenced temp menu id list</param>
        /// <param name="tmpMenuList">referenced temp menu id to menu object dictionary</param>
        private void loopMenusAddToList(Dictionary<string, ICustomMenu> menusList)
        {

            foreach (KeyValuePair<string, ICustomMenu> pair in menusList)
            {
                string menuId = pair.Key;
                ICustomMenu menu = pair.Value;
                HandleBeforeMenus(menuId);
                bool replacing = false;
                if (!removedMenus.Contains(menuId))
                {
                    if (replacementmenusList.ContainsKey(menuId))
                    {
                        replacementmenusList.TryGetValue(menuId, out menu);
                        replacing = true;
                    }
                    //If we haven't already added it add it to the list. avoids later menus being added more than once if they trigger the
                    // before menu or after menu conditions on an earlier menu ?? hopefuly
                    if (!usedMenuIds.Contains(menuId))
                    {
                        usedMenuIds.Add(menuId);
                        finalMenuList.Add(menuId, menu);
                    }
                    // If its been added before but we are replacing the menu replace it with the replacement menu
                    if (usedMenuIds.Contains(menuId) && replacing)
                    {
                        finalMenuList[menuId] = menu;
                    }
                }

                HandleAfterMenus(menuId);


            }
        }
        /// <summary>
        /// Method to get the before menus list to be processed for the specified menuId
        /// </summary>
        /// <param name="menuId">string menu id</param>
        /// <param name="tmpList"> referenced temp menu id list</param>
        /// <param name="tmpMenuList">referenced temp menu id to menu object dictionary</param>
        private void HandleBeforeMenus(string menuId)
        {
            if (beforeMenus.ContainsKey(menuId))
            {
                List<string> beforeMenuIdsList = beforeMenus[menuId];
                HandleBeforeAfterMenuList(beforeMenuIdsList);
            }
        }
        /// <summary>
        /// Method to get the after menus list to be processed for the specified menuId
        /// </summary>
        /// <param name="menuId">string menu id</param>
        /// <param name="tmpList"> referenced temp menu id list</param>
        /// <param name="tmpMenuList">referenced temp menu id to menu object dictionary</param>
        private void HandleAfterMenus(string menuId)
        {
            if (afterMenus.ContainsKey(menuId))
            {
                List<string> afterMenusMenuIdsList = afterMenus[menuId];
                HandleBeforeAfterMenuList(afterMenusMenuIdsList);
            }
        }
        /// <summary>
        ///  Method handles the checking of before and after menu lists 
        /// </summary>
        /// <param name="menuId">string menu id</param>
        /// <param name="tmpList"> referenced temp menu id list</param>
        /// <param name="tmpMenuList">referenced temp menu id to menu object dictionary</param>
        private void HandleBeforeAfterMenuList(List<string> menuIdsList)
        {
            if (menuIdsList.Count > 0)
            {
                foreach (string menuId in menuIdsList)
                {
                    bool replacing = false;
                    ICustomMenu menu = GetMenuToAdd(menuId);

                    if (replacementmenusList.ContainsKey(menuId))
                    {
                        replacementmenusList.TryGetValue(menuId, out menu);
                        replacing = true;
                    }
                    //If we haven't already added it add it to the list. avoids later menus being added more than once if they trigger the
                    // before menu or after menu conditions on an earlier menu ?? hopefuly
                    if (!usedMenuIds.Contains(menuId))
                    {
                        usedMenuIds.Add(menuId);
                        if (menu != null)
                        {
                            finalMenuList.Add(menuId, menu);
                        }
                    }
                    // If its been added before but we are replacing the menu replace it with the replacement menu
                    if (usedMenuIds.Contains(menuId) && replacing)
                    {
                        finalMenuList[menuId] = menu;
                    }
                }
            }
        }
        /// <summary>
        /// Privater method to get the menu object from the temp menu Dictionary list and return it
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns>ICustomMenu menu object</returns>
        private ICustomMenu GetMenuToAdd(string menuId)
        {
            finalMenuList.TryGetValue(menuId, out ICustomMenu menuObject);
            return menuObject;
        }

        /// <summary>
        /// Method to Build the menus
        /// </summary>
        /// <param name="characterCreation">CharacterCreation characterCreation</param>
        public void BuildMenus(CharacterCreation characterCreation)
        {
            foreach (KeyValuePair<string, ICustomMenu> pairs in finalMenuList)
            {
                string menuId = pairs.Key;
                ICustomMenu menu = pairs.Value;
                CharacterCreationMenu customMenu = new CharacterCreationMenu(
                    menu.title,
                    menu.description,
                    menu.CreationOnInit);

                if (menu.textVariable != "")
                {
                    MBTextManager.SetTextVariable(menu.textVariable, menu.variableValue);
                }

                if (menu.RestrictedOptions.Count > 0)
                {
                    foreach (KeyValuePair<CharacterCreationOnCondition, List<CMenuOption>> pair in menu.RestrictedOptions)
                    {
                        CharacterCreationOnCondition condition = pair.Key;
                        List<CMenuOption> optionList = pair.Value;
                        CharacterCreationCategory creationCategory = customMenu.AddMenuCategory(condition);

                        foreach (CMenuOption option in optionList)
                        {
                            creationCategory.AddCategoryOption(option.optionText,
                                                                  option.effectedSkills,
                                                                  option.effectedAttribute,
                                                                  option.focusToAdd,
                                                                  option.skillLevelToAdd,
                                                                  option.attributeLevelToAdd,
                                                                  option.optionCondition,
                                                                  option.onSelect,
                                                                  option.onApply,
                                                                  option.descriptionText,
                                                                  option.effectedTraits,
                                                                  option.traitLevelToAdd,
                                                                  option.renownToAdd,
                                                                  option.goldToAdd,
                                                                  option.unspentFocusPoint,
                                                                  option.unspentAttributePoint
                                                                  );
                        }
                    }
                    characterCreation.AddNewMenu(customMenu);
                }
                if (menu.OptionsList.Count > 0)
                {
                    CharacterCreationCategory creationCategory = customMenu.AddMenuCategory();
                    foreach (CMenuOption option in menu.OptionsList)
                    {
                        creationCategory.AddCategoryOption(option.optionText,
                                                            option.effectedSkills,
                                                            option.effectedAttribute,
                                                            option.focusToAdd,
                                                            option.skillLevelToAdd,
                                                            option.attributeLevelToAdd,
                                                            option.optionCondition,
                                                            option.onSelect,
                                                            option.onApply,
                                                            option.descriptionText,
                                                            option.effectedTraits,
                                                            option.traitLevelToAdd,
                                                            option.renownToAdd,
                                                            option.goldToAdd,
                                                            option.unspentFocusPoint,
                                                            option.unspentAttributePoint
                                                            );
                    }
                    characterCreation.AddNewMenu(customMenu);
                }
            }
        }

        public void TestMenuList(CharacterCreation characterCreation, KaosesStoryModeCharacterCreationContent characterCreationContent)
        {
            foreach (ICustomMenu menu in subObjectsList)
            {
                //menu.Initialise(characterCreation, characterCreationContent);

                IM.MessageDebug("menu.Id: " + menu.Id + "  menu.title: " + menu.title);
                foreach (KeyValuePair<CharacterCreationOnCondition, List<CMenuOption>> pair in menu.RestrictedOptions)
                {
                    IM.MessageDebug("First Dictionary Foreach loop");
                    CharacterCreationOnCondition condition = pair.Key;
                    List<CMenuOption> optionList = pair.Value;
                    IM.MessageDebug("condition : " + condition.ToString());
                    IM.MessageDebug("optionList.Count : " + optionList.Count);
                    foreach (CMenuOption option in optionList)
                    {
                        IM.MessageDebug("Menu ID: " + option.optionText +
                            "focusToAdd: " + option.focusToAdd +
                            "skillLevelToAdd: " + option.skillLevelToAdd +
                            "attributeLevelToAdd: " + option.attributeLevelToAdd +
                            "effectedTraits: " + option.effectedTraits.ToString() +
                            "effectedSkills: " + option.effectedSkills.ToString() +
                            "effectedAttribute: " + option.effectedAttribute.ToString() +
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

        }

        public void TestNewMenVariables(CharacterCreation characterCreation)
        {
            /*
             
        List<ICustomMenu> subObjectsList = new List<ICustomMenu>();
        List<ICustomMenu> finalMenuList = new List<ICustomMenu>();
        public CharacterCreation CharacterCreation;

        protected List<CMenuOption> optionsList = new List<CMenuOption>();
        Dictionary<string, CMenuOption> replacementOptions = new Dictionary<string, CMenuOption>();


        Dictionary<string, ICustomMenu> tmpMenusList = new Dictionary<string, ICustomMenu>();
        Dictionary<string, ICustomMenu> nativeMenusList = new Dictionary<string, ICustomMenu>();


        Dictionary<string, ICustomMenu> startMenus = new Dictionary<string, ICustomMenu>();
        Dictionary<string, ICustomMenu> endMenus = new Dictionary<string, ICustomMenu>();
        Dictionary<string, ICustomMenu> defaultMenus = new Dictionary<string, ICustomMenu>();
        Dictionary<string, ICustomMenu> replacementmenusList = new Dictionary<string, ICustomMenu>();
        List<string> removedMenus = new List<string>();

        Dictionary<string, List<string>> beforeMenus = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> afterMenus = new Dictionary<string, List<string>>(); 
        */
            IM.MessageDebug("subObjectsList Count: " + subObjectsList.Count.ToString());
            //IM.MessageDebug("finalMenuList Count: " + finalMenuList.Count.ToString());
            IM.MessageDebug("optionsList Count: " + optionsList.Count.ToString());
            IM.MessageDebug("replacementOptions Count: " + replacementOptions.Count.ToString());
            IM.MessageDebug("tmpMenusList Count: " + finalMenuList.Count.ToString());
            IM.MessageDebug("nativeMenusList Count: " + nativeMenusList.Count.ToString());
            IM.MessageDebug("startMenus Count: " + startMenus.Count.ToString());
            IM.MessageDebug("endMenus Count: " + endMenus.Count.ToString());
            IM.MessageDebug("defaultMenus Count: " + defaultMenus.Count.ToString());
            IM.MessageDebug("replacementmenusList Count: " + replacementmenusList.Count.ToString());
            IM.MessageDebug("removedMenus Count: " + removedMenus.Count.ToString());
            IM.MessageDebug("beforeMenus Count: " + beforeMenus.Count.ToString());
            IM.MessageDebug("afterMenus Count: " + afterMenus.Count.ToString());
            if (finalMenuList.Count > 0)
            {
                foreach (KeyValuePair<string, ICustomMenu> pairs in finalMenuList)
                {
                    string menuId = pairs.Key;
                    ICustomMenu menu = pairs.Value;

                    IM.MessageDebug("menuId: " + menuId + "  menu.title: " + menu.title);
                }
            }

            /*foreach (KeyValuePair<string, ICustomMenu> pairs in tmpMenusList)
            {
                string menuId = pairs.Key;
                ICustomMenu menu = pairs.Value;
                CharacterCreationMenu customMenu = new CharacterCreationMenu(
                    menu.title,
                    menu.description,
                    menu.CreationOnInit);

                if (menu.textVariable != "")
                {
                    MBTextManager.SetTextVariable(menu.textVariable, menu.variableValue);
                }

                if (menu.RestrictedOptions.Count > 0)
                {
                    foreach (KeyValuePair<CharacterCreationOnCondition, List<CMenuOption>> pair in menu.RestrictedOptions)
                    {
                        CharacterCreationOnCondition condition = pair.Key;
                        List<CMenuOption> optionList = pair.Value;
                        CharacterCreationCategory creationCategory = customMenu.AddMenuCategory(condition);

                        foreach (CMenuOption option in optionList)
                        {
                            creationCategory.AddCategoryOption(option.optionText,
                                                                  option.effectedSkills,
                                                                  option.effectedAttribute,
                                                                  option.focusToAdd,
                                                                  option.skillLevelToAdd,
                                                                  option.attributeLevelToAdd,
                                                                  option.optionCondition,
                                                                  option.onSelect,
                                                                  option.onApply,
                                                                  option.descriptionText);
                        }
                    }
                    characterCreation.AddNewMenu(customMenu);
                }
                if (menu.OptionsList.Count > 0)
                {
                    CharacterCreationCategory creationCategory = customMenu.AddMenuCategory();
                    foreach (CMenuOption option in menu.OptionsList)
                    {
                        creationCategory.AddCategoryOption(option.optionText,
                                                              option.effectedSkills,
                                                              option.effectedAttribute,
                                                              option.focusToAdd,
                                                              option.skillLevelToAdd,
                                                              option.attributeLevelToAdd,
                                                              option.optionCondition,
                                                              option.onSelect,
                                                              option.onApply,
                                                              option.descriptionText);
                    }
                    characterCreation.AddNewMenu(customMenu);
                }
                IM.MessageDebug("newmenu.Title: " + customMenu.Title.ToString());
            }*/
        }

    }
}

