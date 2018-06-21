using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
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
    <Hash>fadc12b0cebf73da7be5b5c8edc4b700</Hash>
</Codenesium>*/