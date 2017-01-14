﻿using OpenNos.Data;
using OpenNos.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenNos.DAL.Mock
{
    public class SynchronizableBaseDAO<TSynchronizableBaseDTO> : BaseDAO<TSynchronizableBaseDTO>
        where TSynchronizableBaseDTO : SynchronizableBaseDTO
    {
        #region Methods

        public DeleteResult Delete(Guid id)
        {
            TSynchronizableBaseDTO dto = LoadById(id);
            Container.Remove(dto);
            return DeleteResult.Deleted;
        }

        public IEnumerable<TSynchronizableBaseDTO> InsertOrUpdate(IEnumerable<TSynchronizableBaseDTO> dtos)
        {
            foreach (TSynchronizableBaseDTO dto in dtos)
            {
                InsertOrUpdate(dto);
            }

            return dtos;
        }

        public TSynchronizableBaseDTO InsertOrUpdate(TSynchronizableBaseDTO dto)
        {
            TSynchronizableBaseDTO loadedDTO = LoadById(dto.Id);
            if (loadedDTO != null)
            {
                return loadedDTO = dto;
            }
            else
            {
                return Insert(dto);
            }
        }

        public TSynchronizableBaseDTO LoadById(Guid id)
        {
            return Container.SingleOrDefault(s => s.Id.Equals(id));
        }

        #endregion
    }
}