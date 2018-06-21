using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>29283ed3fad8e480093f1489715acc7f</Hash>
</Codenesium>*/