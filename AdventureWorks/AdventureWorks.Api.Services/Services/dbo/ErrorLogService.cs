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
        public class ErrorLogService: AbstractErrorLogService, IErrorLogService
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
                               dalerrorLogMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a64a2bb6679156d1c8efe7fac3a959e7</Hash>
</Codenesium>*/