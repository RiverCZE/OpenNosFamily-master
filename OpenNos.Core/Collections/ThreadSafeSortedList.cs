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

using System;
using System.Collections.Generic;
using System.Threading;

namespace OpenNos.Core.Collections
{
    /// <summary>
    /// This class is used to store key-value based items in a thread safe manner.
    /// It uses System.Collections.Generic.SortedList publicly.
    /// </summary>
    /// <typeparam name="TK">Key type</typeparam>
    /// <typeparam name="TV">Value type</typeparam>
    public class ThreadSafeSortedList<TK, TV> : IDisposable
    {
        #region Members

        /// <summary>
        /// public collection to store items.
        /// </summary>
        protected readonly SortedList<TK, TV> Items;

        /// <summary>
        /// Used to synchronize access to _items list.
        /// </summary>
        protected readonly ReaderWriterLockSlim Lock;

        private bool _disposed;

        #endregion

        #region Instantiation

        /// <summary>
        /// Creates a new ThreadSafeSortedList object.
        /// </summary>
        public ThreadSafeSortedList()
        {
            Items = new SortedList<TK, TV>();
            Lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets count of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                Lock.EnterReadLock();
                try
                {
                    return Items.Count;
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets/adds/replaces an item by key.
        /// </summary>
        /// <param name="key">Key to get/set value</param>
        /// <returns>Item associated with this key</returns>
        public TV this[TK key]
        {
            get
            {
                Lock.EnterReadLock();
                try
                {
                    return Items.ContainsKey(key) ? Items[key] : default(TV);
                }
                finally
                {
                    Lock.ExitReadLock();
                }
            }

            set
            {
                Lock.EnterWriteLock();
                try
                {
                    Items[key] = value;
                }
                finally
                {
                    Lock.ExitWriteLock();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Removes all items from list.
        /// </summary>
        public void ClearAll()
        {
            Lock.EnterWriteLock();
            try
            {
                Items.Clear();
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ClearAll();
                Lock.Dispose();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }

        /// <summary>
        /// Checks if collection contains spesified key.
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True; if collection contains given key</returns>
        public bool ContainsKey(TK key)
        {
            Lock.EnterReadLock();
            try
            {
                return Items.ContainsKey(key);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        /// <summary>
        /// Checks if collection contains spesified item.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns>True; if collection contains given item</returns>
        public bool ContainsValue(TV item)
        {
            Lock.EnterReadLock();
            try
            {
                return Items.ContainsValue(item);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        /// <summary>
        /// Gets all items in collection.
        /// </summary>
        /// <returns>Item list</returns>
        public List<TV> GetAllItems()
        {
            Lock.EnterReadLock();
            try
            {
                return new List<TV>(Items.Values);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }

        /// <summary>
        /// Gets then removes all items in collection.
        /// </summary>
        /// <returns>Item list</returns>
        public List<TV> GetAndClearAllItems()
        {
            Lock.EnterWriteLock();
            try
            {
                var list = new List<TV>(Items.Values);
                Items.Clear();
                return list;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Removes an item from collection.
        /// </summary>
        /// <param name="key">Key of item to remove</param>
        public bool Remove(TK key)
        {
            Lock.EnterWriteLock();
            try
            {
                if (!Items.ContainsKey(key))
                {
                    return false;
                }

                Items.Remove(key);
                return true;
            }
            finally
            {
                Lock.ExitWriteLock();
            }
        }

        #endregion
    }
}