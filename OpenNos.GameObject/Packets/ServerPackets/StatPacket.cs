﻿////<auto-generated <- Codemaid exclusion for now (PacketIndex Order is important for maintenance)
using OpenNos.Core;

namespace OpenNos.GameObject
{
    [Header("stat")]
    public class StatPacket : PacketBase
    {
        #region Properties

        [PacketIndex(0)]
        public int CurrentHp { get; set; }

        [PacketIndex(1)]
        public int MaxHp { get; set; }

        [PacketIndex(2)]
        public short CurrentMp { get; set; }

        [PacketIndex(3)]
        public short MaxMp { get; set; }

        [PacketIndex(4)]
        public byte Unknown { get; set; }

        [PacketIndex(5)]
        public short Options { get; set; }

        #endregion
    }
}