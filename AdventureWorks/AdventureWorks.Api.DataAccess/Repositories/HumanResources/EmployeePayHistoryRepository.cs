using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class EmployeePayHistoryRepository : AbstractEmployeePayHistoryRepository, IEmployeePayHistoryRepository
        {
                public EmployeePayHistoryRepository(
                        ILogger<EmployeePayHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bfac084062346bda5bbf7b5ca58798c7</Hash>
</Codenesium>*/