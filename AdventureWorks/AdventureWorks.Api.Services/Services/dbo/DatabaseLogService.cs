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
                        IDALDatabaseLogMapper daldatabaseLogMapper)
                        : base(logger,
                               databaseLogRepository,
                               databaseLogModelValidator,
                               boldatabaseLogMapper,
                               daldatabaseLogMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>94c162ba0d6050330dfe11b17497c9c6</Hash>
</Codenesium>*/