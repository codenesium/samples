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
        public partial class DepartmentService : AbstractDepartmentService, IDepartmentService
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
    <Hash>8605dea359411aea4f73c4369e48a2d0</Hash>
</Codenesium>*/