using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class StateProvinceRepository : AbstractStateProvinceRepository, IStateProvinceRepository
        {
                public StateProvinceRepository(
                        ILogger<StateProvinceRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c1ffc47652c79632ba0d2f13bdb8e8fe</Hash>
</Codenesium>*/