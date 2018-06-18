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
                        ILogger<IShipMethodRepository> logger,
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
    <Hash>352345f0f82de50cb9ed1528fc15926c</Hash>
</Codenesium>*/