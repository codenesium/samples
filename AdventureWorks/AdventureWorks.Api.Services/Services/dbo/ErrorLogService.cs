using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ErrorLogService : AbstractErrorLogService, IErrorLogService
        {
                public ErrorLogService(
                        ILogger<IErrorLogRepository> logger,
                        IErrorLogRepository errorLogRepository,
                        IApiErrorLogRequestModelValidator errorLogModelValidator,
                        IBOLErrorLogMapper bolerrorLogMapper,
                        IDALErrorLogMapper dalerrorLogMapper
                        )
                        : base(logger,
                               errorLogRepository,
                               errorLogModelValidator,
                               bolerrorLogMapper,
                               dalerrorLogMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9b68e091086652977354f747d1b534bc</Hash>
</Codenesium>*/