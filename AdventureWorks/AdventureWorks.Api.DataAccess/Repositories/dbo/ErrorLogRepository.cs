using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ErrorLogRepository: AbstractErrorLogRepository, IErrorLogRepository
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
    <Hash>81fd14c278d56b72b166da60b9cbbd50</Hash>
</Codenesium>*/