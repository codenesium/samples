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
        public class EmployeePayHistoryService : AbstractEmployeePayHistoryService, IEmployeePayHistoryService
        {
                public EmployeePayHistoryService(
                        ILogger<IEmployeePayHistoryRepository> logger,
                        IEmployeePayHistoryRepository employeePayHistoryRepository,
                        IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
                        IBOLEmployeePayHistoryMapper bolemployeePayHistoryMapper,
                        IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper
                        )
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
    <Hash>5958fd979ed9bfd34f4077157cb2b97b</Hash>
</Codenesium>*/