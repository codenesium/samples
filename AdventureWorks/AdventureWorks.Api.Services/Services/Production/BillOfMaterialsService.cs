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
        public class BillOfMaterialsService : AbstractBillOfMaterialsService, IBillOfMaterialsService
        {
                public BillOfMaterialsService(
                        ILogger<IBillOfMaterialsRepository> logger,
                        IBillOfMaterialsRepository billOfMaterialsRepository,
                        IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator,
                        IBOLBillOfMaterialsMapper bolbillOfMaterialsMapper,
                        IDALBillOfMaterialsMapper dalbillOfMaterialsMapper
                        )
                        : base(logger,
                               billOfMaterialsRepository,
                               billOfMaterialsModelValidator,
                               bolbillOfMaterialsMapper,
                               dalbillOfMaterialsMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>14273aa5473f1da07cbc4755da9ae87e</Hash>
</Codenesium>*/