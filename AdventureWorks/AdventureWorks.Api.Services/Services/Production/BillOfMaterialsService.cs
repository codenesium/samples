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
                        ILogger<BillOfMaterialsRepository> logger,
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
    <Hash>4755b7e49dbd05e0b9deb9e9b9240cd8</Hash>
</Codenesium>*/