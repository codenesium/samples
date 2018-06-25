using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ShiftRepository : AbstractShiftRepository, IShiftRepository
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
    <Hash>95bb02ba690c42a2772bb2b9866763a3</Hash>
</Codenesium>*/