using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ShipMethodService : AbstractShipMethodService, IShipMethodService
        {
                public ShipMethodService(
                        ILogger<IShipMethodRepository> logger,
                        IShipMethodRepository shipMethodRepository,
                        IApiShipMethodRequestModelValidator shipMethodModelValidator,
                        IBOLShipMethodMapper bolshipMethodMapper,
                        IDALShipMethodMapper dalshipMethodMapper,
                        IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper
                        )
                        : base(logger,
                               shipMethodRepository,
                               shipMethodModelValidator,
                               bolshipMethodMapper,
                               dalshipMethodMapper,
                               bolPurchaseOrderHeaderMapper,
                               dalPurchaseOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3a99dcc991924f525970245c2f04ea10</Hash>
</Codenesium>*/