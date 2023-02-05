﻿using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using System.Linq;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.GauntletUI;

namespace CharacterCreationMenuFramework.Objects
{
    public class CulturedStartManager
    {
        private static readonly CulturedStartManager _culturedStartManager = new CulturedStartManager();
        protected bool _nativeMenus = false;
        protected bool _randomPackages = false;
        protected bool _PackagesSelection = false;


        public static CulturedStartManager Instance => _culturedStartManager;

        // 0 = Default, 1 = Skip
        public int QuestOption { get; set; }

        // 0 = Default, 1 = Merchant, 2 = Exiled, 3 = Mercenary, 4 = Looter, 5 = Vassal, 6 = Kingdom, 7 = Holding, 8 = Landed Vassal, 9 = Escaped Prisoner
        public int StartOption { get; set; }

        // 0 = Hometown, 1 = Random, 2 - 7 = Specific Town, 8 = Castle, 9 = Escaping
        public int LocationOption { get; set; }

        public Settlement CastleToAdd { get; set; }

        public Hero CaptorToEscapeFrom { get; set; }

        public Settlement StartingSettlement
        {
            get
            {
                switch (LocationOption)
                {
                    case 0:
                        return Hero.MainHero.HomeSettlement;
                    case 1:
                        return Settlement.FindAll(settlement => settlement.IsTown).GetRandomElementInefficiently();
                    case 2:
                        return Settlement.Find("town_A8");
                    case 3:
                        return Settlement.Find("town_B2");
                    case 4:
                        return Settlement.Find("town_EW2");
                    case 5:
                        return Settlement.Find("town_S2");
                    case 6:
                        return Settlement.Find("town_K4");
                    case 7:
                        return Settlement.Find("town_V3");
                    case 8:
                        return CastleToAdd;
                    default:
                        return Settlement.Find("tutorial_training_field");
                }
            }
        }

        public Vec2 StartingPosition => LocationOption != 9 ? StartingSettlement.GatePosition : CaptorToEscapeFrom.PartyBelongedTo.Position2D;

        public void SetQuestOption(int questOption) => QuestOption = questOption;

        public void SetStartOption(int startOption) => StartOption = startOption;

        public void SetLocationOption(int locationOption) => LocationOption = locationOption;

        public void SetCastleToAdd() => CastleToAdd = (from settlement in Settlement.All
                                                       where settlement.Culture == Hero.MainHero.Culture && settlement.IsCastle
                                                       select settlement).GetRandomElementInefficiently();

        public void SetCaptorToEscapeFrom() => CaptorToEscapeFrom = Hero.FindAll(hero => (hero.Culture == Hero.MainHero.Culture) && hero.IsAlive && hero.MapFaction != null && !hero.MapFaction.IsMinorFaction && hero.IsPartyLeader && hero.PartyBelongedTo.DefaultBehavior != AiBehavior.Hold).GetRandomElementInefficiently();


        public bool UseNativeMenus
        {
            get { return _nativeMenus; }
            set { _nativeMenus = value; }
        }
        public bool UseAllRandom
        {
            get { return _randomPackages; }
            set { _randomPackages = value; }
        }
        public bool UsePackages
        {
            get { return _PackagesSelection; }
            set { _PackagesSelection = value; }
        }
        public void SetNativeMenus() => _nativeMenus = true;
        public void SetAllRandom() => _randomPackages = true;
        public void SetPackageSelection() => _PackagesSelection = true;





    }
}