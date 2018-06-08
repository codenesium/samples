using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class DepartmentRepository: AbstractDepartmentRepository, IDepartmentRepository
        {
                public DepartmentRepository(
                        ILogger<DepartmentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ecae5f1be7e675e301b6ab7be610e56e</Hash>
</Codenesium>*/