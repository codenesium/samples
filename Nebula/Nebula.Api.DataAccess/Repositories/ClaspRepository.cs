using Codenesium.DataConversionExtensions;
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
    <Hash>fbb5d3bf036ce06243689a1c2373686e</Hash>
</Codenesium>*/