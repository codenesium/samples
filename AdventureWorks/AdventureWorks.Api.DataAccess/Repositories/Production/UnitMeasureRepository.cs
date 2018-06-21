using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class UnitMeasureRepository : AbstractUnitMeasureRepository, IUnitMeasureRepository
        {
                public UnitMeasureRepository(
                        ILogger<UnitMeasureRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d72c0726e7c053eb7913f03dcb350231</Hash>
</Codenesium>*/