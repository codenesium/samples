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
                               dalemployeeDepartmentHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>de603e43e1c07cc1a8b60d92e6743fc1</Hash>
</Codenesium>*/