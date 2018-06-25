using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class DepartmentRepository : AbstractDepartmentRepository, IDepartmentRepository
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
    <Hash>37abd31b5263f04be35f2ce4ded3fb27</Hash>
</Codenesium>*/