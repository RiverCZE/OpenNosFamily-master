/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

namespace OpenNos.DAL.EF.MySQL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Character
    {
        #region Instantiation

        public Character()
        {
            CharacterSkill = new HashSet<CharacterSkill>();
            Inventory = new HashSet<Inventory>();
            QuicklistEntry = new HashSet<QuicklistEntry>();
            Respawn = new HashSet<Respawn>();
            GeneralLog = new HashSet<GeneralLog>();
            Mail = new HashSet<Mail>();
            Mail1 = new HashSet<Mail>();
        }

        #endregion

        #region Properties

        public virtual Account Account { get; set; }

        public long AccountId { get; set; }

        public int Act4Dead { get; set; }

        public int Act4Kill { get; set; }

        public int Act4Points { get; set; }

        public int ArenaWinner { get; set; }

        public int Backpack { get; set; }

        public string Biography { get; set; }

        public bool BuffBlocked { get; set; }

        public long CharacterId { get; set; }

        public virtual ICollection<CharacterSkill> CharacterSkill { get; set; }

        public byte Class { get; set; }

        public short Compliment { get; set; }

        public float Dignity { get; set; }

        public bool EmoticonsBlocked { get; set; }

        public bool ExchangeBlocked { get; set; }

        public int Faction { get; set; }

        public long FamilyId { get; set; }

        public int FamilyLevel { get; set; }

        public bool FamilyRequestBlocked { get; set; }

        public bool FriendRequestBlocked { get; set; }

        public byte Gender { get; set; }

        public virtual ICollection<GeneralLog> GeneralLog { get; set; }

        public long Gold { get; set; }

        public bool GroupRequestBlocked { get; set; }

        public byte HairColor { get; set; }

        public byte HairStyle { get; set; }

        public bool HeroChatBlocked { get; set; }

        public byte HeroLevel { get; set; }

        public long HeroXp { get; set; }

        public int Hp { get; set; }

        public bool HpBlocked { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }

        public byte JobLevel { get; set; }

        public long JobLevelXp { get; set; }

        public byte Level { get; set; }

        public long LevelXp { get; set; }

        public virtual ICollection<Mail> Mail { get; set; }

        public virtual ICollection<Mail> Mail1 { get; set; }

        public virtual Map Map { get; set; }

        public short MapId { get; set; }

        public short MapX { get; set; }

        public short MapY { get; set; }

        public int MasterPoints { get; set; }

        public int MasterTicket { get; set; }

        public bool MinilandInviteBlocked { get; set; }

        public bool MouseAimLock { get; set; }

        public int Mp { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string FamilyPosition { get; set; }

        public string FamilyInfo { get; set; }

        public string FamilyName { get; set; }

        public bool QuickGetUp { get; set; }

        public virtual ICollection<QuicklistEntry> QuicklistEntry { get; set; }

        public long RagePoint { get; set; }

        public long Reput { get; set; }

        public virtual ICollection<Respawn> Respawn { get; set; }

        public byte Slot { get; set; }

        public int SpAdditionPoint { get; set; }

        public int SpPoint { get; set; }

        public byte State { get; set; }

        public int TalentLose { get; set; }

        public int TalentSurrender { get; set; }

        public int TalentWin { get; set; }

        public bool WhisperBlocked { get; set; }

        #endregion
    }
}