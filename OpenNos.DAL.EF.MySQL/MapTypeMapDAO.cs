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
    public class MapTypeMapDAO : IMapTypeMapDAO
    {
        #region Members

        private IMapper _mapper;

        #endregion

        #region Instantiation

        public MapTypeMapDAO()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MapTypeMap, MapTypeMapDTO>();
                cfg.CreateMap<MapTypeMapDTO, MapTypeMap>();
            });

            _mapper = config.CreateMapper();
        }

        #endregion

        #region Methods

        public void Insert(List<MapTypeMapDTO> maptypemaps)
        {
            try
            {
                using (var context = DataAccessHelper.CreateContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    foreach (MapTypeMapDTO MapTypeMap in maptypemaps)
                    {
                        MapTypeMap entity = _mapper.Map<MapTypeMap>(MapTypeMap);
                        context.MapTypeMap.Add(entity);
                    }
                    context.Configuration.AutoDetectChangesEnabled = true;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public IEnumerable<MapTypeMapDTO> LoadAll()
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (MapTypeMap MapTypeMap in context.MapTypeMap)
                {
                    yield return _mapper.Map<MapTypeMapDTO>(MapTypeMap);
                }
            }
        }

        public MapTypeMapDTO LoadByMapAndMapType(short mapId, short maptypeId)
        {
            try
            {
                using (var context = DataAccessHelper.CreateContext())
                {
                    return _mapper.Map<MapTypeMapDTO>(context.MapTypeMap.FirstOrDefault(i => i.MapId.Equals(mapId) && i.MapTypeId.Equals(maptypeId)));
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public IEnumerable<MapTypeMapDTO> LoadByMapId(short mapId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (MapTypeMap MapTypeMap in context.MapTypeMap.Where(c => c.MapId.Equals(mapId)))
                {
                    yield return _mapper.Map<MapTypeMapDTO>(MapTypeMap);
                }
            }
        }

        public IEnumerable<MapTypeMapDTO> LoadByMapTypeId(short maptypeId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (MapTypeMap MapTypeMap in context.MapTypeMap.Where(c => c.MapTypeId.Equals(maptypeId)))
                {
                    yield return _mapper.Map<MapTypeMapDTO>(MapTypeMap);
                }
            }
        }

        #endregion
    }
}