﻿/*
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

using AutoMapper;
using OpenNos.Core;
using OpenNos.DAL.EF.MySQL.Helpers;
using OpenNos.DAL.Interface;
using OpenNos.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenNos.DAL.EF.MySQL
{
    public class TeleporterDAO : ITeleporterDAO
    {
        #region Members

        private IMapper _mapper;

        #endregion

        #region Instantiation

        public TeleporterDAO()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Teleporter, TeleporterDTO>();
                cfg.CreateMap<TeleporterDTO, Teleporter>();
            });

            _mapper = config.CreateMapper();
        }

        #endregion

        #region Methods

        public TeleporterDTO Insert(TeleporterDTO teleporter)
        {
            try
            {
                using (var context = DataAccessHelper.CreateContext())
                {
                    Teleporter entity = _mapper.Map<Teleporter>(teleporter);
                    context.Teleporter.Add(entity);
                    context.SaveChanges();
                    return _mapper.Map<TeleporterDTO>(entity);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public TeleporterDTO LoadById(short teleporterId)
        {
            try
            {
                using (var context = DataAccessHelper.CreateContext())
                {
                    return _mapper.Map<TeleporterDTO>(context.Teleporter.FirstOrDefault(i => i.TeleporterId.Equals(teleporterId)));
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public IEnumerable<TeleporterDTO> LoadFromNpc(int npcId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (Teleporter Teleporterobject in context.Teleporter.Where(c => c.MapNpcId.Equals(npcId)))
                {
                    yield return _mapper.Map<TeleporterDTO>(Teleporterobject);
                }
            }
        }

        #endregion
    }
}