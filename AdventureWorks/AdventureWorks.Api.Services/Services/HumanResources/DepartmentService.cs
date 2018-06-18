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
        public class DepartmentService: AbstractDepartmentService, IDepartmentService
        {
                public DepartmentService(
                        ILogger<IDepartmentRepository> logger,
                        IDepartmentRepository departmentRepository,
                        IApiDepartmentRequestModelValidator departmentModelValidator,
                        IBOLDepartmentMapper boldepartmentMapper,
                        IDALDepartmentMapper daldepartmentMapper
                        ,
                        IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper

                        )
                        : base(logger,
                               departmentRepository,
                               departmentModelValidator,
                               boldepartmentMapper,
                               daldepartmentMapper
                               ,
                               bolEmployeeDepartmentHistoryMapper,
                               dalEmployeeDepartmentHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>51257b6af3a35f9fe8710c9bcbfe42c7</Hash>
</Codenesium>*/