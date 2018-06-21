using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class EmployeeDepartmentHistoryRepository : AbstractEmployeeDepartmentHistoryRepository, IEmployeeDepartmentHistoryRepository
        {
                public EmployeeDepartmentHistoryRepository(
                        ILogger<EmployeeDepartmentHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>baefad25be4fb62afb6e94d9ef9a341a</Hash>
</Codenesium>*/