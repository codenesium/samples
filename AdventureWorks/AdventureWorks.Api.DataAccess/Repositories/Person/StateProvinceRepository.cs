using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class StateProvinceRepository: AbstractStateProvinceRepository, IStateProvinceRepository
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
    <Hash>f516ded45d8e20c8d259cca9326c8ec4</Hash>
</Codenesium>*/