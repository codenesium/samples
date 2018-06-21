using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class DatabaseLogRepository : AbstractDatabaseLogRepository, IDatabaseLogRepository
        {
                public DatabaseLogRepository(
                        ILogger<DatabaseLogRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>06c9edd2dc821d7cac91b6582ba8112a</Hash>
</Codenesium>*/