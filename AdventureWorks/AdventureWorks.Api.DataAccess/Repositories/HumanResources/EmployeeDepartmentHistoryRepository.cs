using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class EmployeeDepartmentHistoryRepository : AbstractEmployeeDepartmentHistoryRepository, IEmployeeDepartmentHistoryRepository
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
    <Hash>efdd8ba8995b727c87f1131052c6a27c</Hash>
</Codenesium>*/