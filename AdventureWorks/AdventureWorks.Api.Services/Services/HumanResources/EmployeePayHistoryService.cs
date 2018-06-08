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
        public class EmployeePayHistoryService: AbstractEmployeePayHistoryService, IEmployeePayHistoryService
        {
                public EmployeePayHistoryService(
                        ILogger<EmployeePayHistoryRepository> logger,
                        IEmployeePayHistoryRepository employeePayHistoryRepository,
                        IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
                        IBOLEmployeePayHistoryMapper bolemployeePayHistoryMapper,
                        IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper)
                        : base(logger,
                               employeePayHistoryRepository,
                               employeePayHistoryModelValidator,
                               bolemployeePayHistoryMapper,
                               dalemployeePayHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fddf78d53784c0da262a9cf16d93f069</Hash>
</Codenesium>*/