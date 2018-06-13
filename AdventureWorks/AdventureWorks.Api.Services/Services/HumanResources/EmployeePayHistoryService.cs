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
                        IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper

                        )
                        : base(logger,
                               employeePayHistoryRepository,
                               employeePayHistoryModelValidator,
                               bolemployeePayHistoryMapper,
                               dalemployeePayHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b92f41e3998055f225fa23791dac8f8b</Hash>
</Codenesium>*/