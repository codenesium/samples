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
        public class EmployeeService: AbstractEmployeeService, IEmployeeService
        {
                public EmployeeService(
                        ILogger<EmployeeRepository> logger,
                        IEmployeeRepository employeeRepository,
                        IApiEmployeeRequestModelValidator employeeModelValidator,
                        IBOLEmployeeMapper bolemployeeMapper,
                        IDALEmployeeMapper dalemployeeMapper
                        ,
                        IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper
                        ,
                        IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper,
                        IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper
                        ,
                        IBOLJobCandidateMapper bolJobCandidateMapper,
                        IDALJobCandidateMapper dalJobCandidateMapper

                        )
                        : base(logger,
                               employeeRepository,
                               employeeModelValidator,
                               bolemployeeMapper,
                               dalemployeeMapper
                               ,
                               bolEmployeeDepartmentHistoryMapper,
                               dalEmployeeDepartmentHistoryMapper
                               ,
                               bolEmployeePayHistoryMapper,
                               dalEmployeePayHistoryMapper
                               ,
                               bolJobCandidateMapper,
                               dalJobCandidateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2c747b213f3d79e0d1355624c0ebe62d</Hash>
</Codenesium>*/