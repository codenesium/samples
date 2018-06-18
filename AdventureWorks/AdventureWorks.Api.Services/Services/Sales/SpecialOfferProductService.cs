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
                        ILogger<ISpecialOfferProductRepository> logger,
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
    <Hash>f02338531b198898768b7610031d467d</Hash>
</Codenesium>*/