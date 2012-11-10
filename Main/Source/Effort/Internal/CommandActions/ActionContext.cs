﻿// --------------------------------------------------------------------------------------------
// <copyright file="ActionContext.cs" company="Effort Team">
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

namespace Effort.Internal.CommandActions
{
    using System.Collections.Generic;
    using System.Data;
    using Effort.Internal.DbManagement;
    using NMemory.Transactions;

    internal sealed class ActionContext
    {
        private DbContainer container;

        public ActionContext(DbContainer container)
        {
            this.container = container;
            this.Parameters = new List<CommandActionParameter>();
        }

        public DbContainer DbContainer
        {
            get { return this.container; }
        }

        public CommandBehavior CommandBehavior { get; set; }

        public IList<CommandActionParameter> Parameters { get; private set; }

        public Transaction Transaction { get; set; }
    }
}