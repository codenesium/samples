using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class EmployeeRepository : AbstractEmployeeRepository, IEmployeeRepository
        {
                public EmployeeRepository(
                        ILogger<EmployeeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f13225cbd181379372a97e95cb0e2d61</Hash>
</Codenesium>*/