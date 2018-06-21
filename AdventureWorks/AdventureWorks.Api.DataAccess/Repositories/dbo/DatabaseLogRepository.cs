using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>fcd0967da859e455710a5d2503c3fff3</Hash>
</Codenesium>*/