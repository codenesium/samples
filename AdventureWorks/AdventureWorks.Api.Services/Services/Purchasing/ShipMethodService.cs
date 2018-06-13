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
                        IDALShipMethodMapper dalshipMethodMapper
                        ,
                        IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper

                        )
                        : base(logger,
                               shipMethodRepository,
                               shipMethodModelValidator,
                               bolshipMethodMapper,
                               dalshipMethodMapper
                               ,
                               bolPurchaseOrderHeaderMapper,
                               dalPurchaseOrderHeaderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f531c7a3563ee1f7c64d26e18142b1ed</Hash>
</Codenesium>*/