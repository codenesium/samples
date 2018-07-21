using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class RowVersionCheckRepository : AbstractRowVersionCheckRepository, IRowVersionCheckRepository
        {
                public RowVersionCheckRepository(
                        ILogger<RowVersionCheckRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>aec8ae46013a749bd5659066b2e4699f</Hash>
</Codenesium>*/