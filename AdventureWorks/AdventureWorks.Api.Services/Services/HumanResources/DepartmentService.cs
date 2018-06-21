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
        public class DepartmentService : AbstractDepartmentService, IDepartmentService
        {
                public DepartmentService(
                        ILogger<IDepartmentRepository> logger,
                        IDepartmentRepository departmentRepository,
                        IApiDepartmentRequestModelValidator departmentModelValidator,
                        IBOLDepartmentMapper boldepartmentMapper,
                        IDALDepartmentMapper daldepartmentMapper,
                        IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper
                        )
                        : base(logger,
                               departmentRepository,
                               departmentModelValidator,
                               boldepartmentMapper,
                               daldepartmentMapper,
                               bolEmployeeDepartmentHistoryMapper,
                               dalEmployeeDepartmentHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>57df528e8dc0e17f76315e2d2589d6b1</Hash>
</Codenesium>*/