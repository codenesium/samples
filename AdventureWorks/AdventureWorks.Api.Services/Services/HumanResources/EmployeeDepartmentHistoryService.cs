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
        public class EmployeeDepartmentHistoryService : AbstractEmployeeDepartmentHistoryService, IEmployeeDepartmentHistoryService
        {
                public EmployeeDepartmentHistoryService(
                        ILogger<IEmployeeDepartmentHistoryRepository> logger,
                        IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
                        IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
                        IBOLEmployeeDepartmentHistoryMapper bolemployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalemployeeDepartmentHistoryMapper
                        )
                        : base(logger,
                               employeeDepartmentHistoryRepository,
                               employeeDepartmentHistoryModelValidator,
                               bolemployeeDepartmentHistoryMapper,
                               dalemployeeDepartmentHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>315ba562b73db64dcf5d82c65c1b9e99</Hash>
</Codenesium>*/