﻿using System;

namespace OpenNos.Data
{
    public abstract class SynchronizableBaseDTO
    {
        #region Instantiation

        public SynchronizableBaseDTO()
        {
            Id = Guid.NewGuid(); //make unique
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            return ((SynchronizableBaseDTO)obj).Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}