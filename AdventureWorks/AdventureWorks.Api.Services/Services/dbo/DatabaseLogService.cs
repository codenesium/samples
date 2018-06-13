using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DatabaseLogService: AbstractDatabaseLogService, IDatabaseLogService
        {
                public DatabaseLogService(
                        ILogger<DatabaseLogRepository> logger,
                        IDatabaseLogRepository databaseLogRepository,
                        IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
                        IBOLDatabaseLogMapper boldatabaseLogMapper,
                        IDALDatabaseLogMapper daldatabaseLogMapper

                        )
                        : base(logger,
                               databaseLogRepository,
                               databaseLogModelValidator,
                               boldatabaseLogMapper,
                               daldatabaseLogMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>be61731abcdad4650c562d440683d170</Hash>
</Codenesium>*/