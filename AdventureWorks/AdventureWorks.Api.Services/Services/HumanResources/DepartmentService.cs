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
                        ILogger<DepartmentRepository> logger,
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
    <Hash>5ebe38835f6ab45c3ca1fcd9b1817ca9</Hash>
</Codenesium>*/