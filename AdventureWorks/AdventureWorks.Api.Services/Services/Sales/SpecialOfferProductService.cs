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
        public class SpecialOfferProductService : AbstractSpecialOfferProductService, ISpecialOfferProductService
        {
                public SpecialOfferProductService(
                        ILogger<ISpecialOfferProductRepository> logger,
                        ISpecialOfferProductRepository specialOfferProductRepository,
                        IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
                        IBOLSpecialOfferProductMapper bolspecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalspecialOfferProductMapper,
                        IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
                        IDALSalesOrderDetailMapper dalSalesOrderDetailMapper
                        )
                        : base(logger,
                               specialOfferProductRepository,
                               specialOfferProductModelValidator,
                               bolspecialOfferProductMapper,
                               dalspecialOfferProductMapper,
                               bolSalesOrderDetailMapper,
                               dalSalesOrderDetailMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7d44d72b2dede3422e787646bc620525</Hash>
</Codenesium>*/