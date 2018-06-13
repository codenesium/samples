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
                        ILogger<ErrorLogRepository> logger,
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
    <Hash>d287e06649673ca424b94e7365bc3a0f</Hash>
</Codenesium>*/