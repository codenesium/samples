using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ErrorLogRepository : AbstractErrorLogRepository, IErrorLogRepository
        {
                public ErrorLogRepository(
                        ILogger<ErrorLogRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a770241a9466dac246717ada30099086</Hash>
</Codenesium>*/