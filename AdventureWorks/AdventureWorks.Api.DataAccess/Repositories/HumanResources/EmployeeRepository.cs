using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class EmployeeRepository : AbstractEmployeeRepository, IEmployeeRepository
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
    <Hash>a4ff2c49c073b78276fabc33f2086dd6</Hash>
</Codenesium>*/