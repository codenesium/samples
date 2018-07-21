using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class TableRepository : AbstractTableRepository, ITableRepository
        {
                public TableRepository(
                        ILogger<TableRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ff623b44ad06be963f508c0e9817277d</Hash>
</Codenesium>*/