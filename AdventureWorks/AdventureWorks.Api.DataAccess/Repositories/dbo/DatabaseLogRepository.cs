using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class DatabaseLogRepository : AbstractDatabaseLogRepository, IDatabaseLogRepository
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
    <Hash>3435b721e905c9c51d5283a8d41cea41</Hash>
</Codenesium>*/