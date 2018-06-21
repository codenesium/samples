using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class DatabaseLogService : AbstractDatabaseLogService, IDatabaseLogService
        {
                public DatabaseLogService(
                        ILogger<IDatabaseLogRepository> logger,
                        IDatabaseLogRepository databaseLogRepository,
                        IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
                        IBOLDatabaseLogMapper boldatabaseLogMapper,
                        IDALDatabaseLogMapper daldatabaseLogMapper
                        )
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
    <Hash>241a07ce377c9685f1bffeb3ec6fcacd</Hash>
</Codenesium>*/