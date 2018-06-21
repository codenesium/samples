using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class ClaspRepository : AbstractClaspRepository, IClaspRepository
        {
                public ClaspRepository(
                        ILogger<ClaspRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1060daac0e0cf52ed5a1b47e56fe639c</Hash>
</Codenesium>*/