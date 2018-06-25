using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class UnitMeasureRepository : AbstractUnitMeasureRepository, IUnitMeasureRepository
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
    <Hash>6d3ef08a4dea88eec5da622c999e9f6b</Hash>
</Codenesium>*/