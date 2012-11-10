﻿// --------------------------------------------------------------------------------------------
// <copyright file="DbSchemaStore.cs" company="Effort Team">
//     Copyright (C) 2012 by Effort Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------

namespace Effort.Internal.Caching
{
    using System;
    using System.Data.Metadata.Edm;
    using Effort.Internal.DbManagement;

    internal static class DbSchemaStore
    {
        private static ConcurrentCache<DbSchemaKey, DbSchema> store;

        static DbSchemaStore()
        {
            store = new ConcurrentCache<DbSchemaKey, DbSchema>();
        }

        public static DbSchema GetDbSchema(
            StoreItemCollection metadata, 
            Func<StoreItemCollection, DbSchema> schemaFactoryMethod)
        {
            return store.Get(new DbSchemaKey(metadata), () => schemaFactoryMethod(metadata));
        }

        public static DbSchema GetDbSchema(DbSchemaKey schemaKey)
        {
            return store.Get(schemaKey);
        }
    }
}