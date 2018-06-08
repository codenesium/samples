using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class DatabaseLogRepository: AbstractDatabaseLogRepository, IDatabaseLogRepository
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
    <Hash>e14e9b0dd94b4240220618f435872f5d</Hash>
</Codenesium>*/