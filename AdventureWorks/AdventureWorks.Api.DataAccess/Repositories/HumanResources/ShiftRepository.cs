using Codenesium.DataConversionExtensions;
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
    <Hash>cd51a7b259177821b661d0dca7712311</Hash>
</Codenesium>*/