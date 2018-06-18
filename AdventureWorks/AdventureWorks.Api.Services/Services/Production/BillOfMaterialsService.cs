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
        public class BillOfMaterialsService: AbstractBillOfMaterialsService, IBillOfMaterialsService
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
                               dalbillOfMaterialsMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f3dfd401d108bbd07aa0f4c45e4f5752</Hash>
</Codenesium>*/