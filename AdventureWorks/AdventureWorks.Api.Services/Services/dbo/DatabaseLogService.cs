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
                               daldatabaseLogMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>0dae045226a6d2cccc063c1047b985db</Hash>
</Codenesium>*/