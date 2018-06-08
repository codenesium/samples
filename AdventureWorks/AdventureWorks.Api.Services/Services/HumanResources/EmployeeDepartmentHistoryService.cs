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
        public class EmployeeDepartmentHistoryService: AbstractEmployeeDepartmentHistoryService, IEmployeeDepartmentHistoryService
        {
                public EmployeeDepartmentHistoryService(
                        ILogger<EmployeeDepartmentHistoryRepository> logger,
                        IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
                        IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
                        IBOLEmployeeDepartmentHistoryMapper bolemployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalemployeeDepartmentHistoryMapper)
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
    <Hash>9697c21dfb62ded36ada9092be9f9c1a</Hash>
</Codenesium>*/