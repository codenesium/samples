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
                        IDALDepartmentMapper daldepartmentMapper)
                        : base(logger,
                               departmentRepository,
                               departmentModelValidator,
                               boldepartmentMapper,
                               daldepartmentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a0676beb863a26e9f0d2272ebcb4f029</Hash>
</Codenesium>*/