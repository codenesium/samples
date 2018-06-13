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
        public class SpecialOfferProductService: AbstractSpecialOfferProductService, ISpecialOfferProductService
        {
                public SpecialOfferProductService(
                        ILogger<SpecialOfferProductRepository> logger,
                        ISpecialOfferProductRepository specialOfferProductRepository,
                        IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
                        IBOLSpecialOfferProductMapper bolspecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalspecialOfferProductMapper
                        ,
                        IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalSalesOrderDetailMapper

                        )
                        : base(logger,
                               specialOfferProductRepository,
                               specialOfferProductModelValidator,
                               bolspecialOfferProductMapper,
                               dalspecialOfferProductMapper
                               ,
                               bolSalesOrderDetailMapper,
                               dalSalesOrderDetailMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>8ffff2b80fdf4b7d4d096577b87198aa</Hash>
</Codenesium>*/