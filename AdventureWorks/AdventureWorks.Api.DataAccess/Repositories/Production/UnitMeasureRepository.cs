using Codenesium.DataConversionExtensions;
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
    <Hash>564ccd76756472d233f31bc2c1d98eeb</Hash>
</Codenesium>*/