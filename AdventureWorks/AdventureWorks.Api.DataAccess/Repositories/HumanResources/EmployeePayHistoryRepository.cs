using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class EmployeePayHistoryRepository : AbstractEmployeePayHistoryRepository, IEmployeePayHistoryRepository
        {
                public EmployeePayHistoryRepository(
                        ILogger<EmployeePayHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>dda905a53d330eefff3ee1dfccd787ce</Hash>
</Codenesium>*/