using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ShiftRepository : AbstractShiftRepository, IShiftRepository
        {
                public ShiftRepository(
                        ILogger<ShiftRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>73f0bf9274f5481bee98378563697c10</Hash>
</Codenesium>*/