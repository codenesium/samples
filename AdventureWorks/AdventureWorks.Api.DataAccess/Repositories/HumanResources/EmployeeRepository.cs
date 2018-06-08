using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class EmployeeRepository: AbstractEmployeeRepository, IEmployeeRepository
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
    <Hash>ae885b9b769ba4946a432b50f5271b14</Hash>
</Codenesium>*/