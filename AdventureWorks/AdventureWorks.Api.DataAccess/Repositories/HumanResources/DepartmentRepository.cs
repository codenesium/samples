using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class DepartmentRepository : AbstractDepartmentRepository, IDepartmentRepository
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
    <Hash>74f25060fe5214591fbabe1f472dd64a</Hash>
</Codenesium>*/