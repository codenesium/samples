using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
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
    <Hash>2fc093482892b8b36e1dbe2265c57b0b</Hash>
</Codenesium>*/