using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ShipMethodService: AbstractShipMethodService, IShipMethodService
        {
                public ShipMethodService(
                        ILogger<ShipMethodRepository> logger,
                        IShipMethodRepository shipMethodRepository,
                        IApiShipMethodRequestModelValidator shipMethodModelValidator,
                        IBOLShipMethodMapper bolshipMethodMapper,
                        IDALShipMethodMapper dalshipMethodMapper)
                        : base(logger,
                               shipMethodRepository,
                               shipMethodModelValidator,
                               bolshipMethodMapper,
                               dalshipMethodMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8744ce81c87c8876ccc8aad5cbb219d5</Hash>
</Codenesium>*/