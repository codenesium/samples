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
        public partial class SpecialOfferProductService : AbstractSpecialOfferProductService, ISpecialOfferProductService
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
    <Hash>fdb09f7265fd678908aa3edd0c73ed30</Hash>
</Codenesium>*/