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
                        IDALErrorLogMapper dalerrorLogMapper)
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
    <Hash>b8f13cca33e7ece4ee268bb67c4e3257</Hash>
</Codenesium>*/