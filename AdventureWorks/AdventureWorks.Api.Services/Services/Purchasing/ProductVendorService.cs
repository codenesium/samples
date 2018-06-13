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
        public class ProductVendorService: AbstractProductVendorService, IProductVendorService
        {
                public ProductVendorService(
                        ILogger<ProductVendorRepository> logger,
                        IProductVendorRepository productVendorRepository,
                        IApiProductVendorRequestModelValidator productVendorModelValidator,
                        IBOLProductVendorMapper bolproductVendorMapper,
                        IDALProductVendorMapper dalproductVendorMapper

                        )
                        : base(logger,
                               productVendorRepository,
                               productVendorModelValidator,
                               bolproductVendorMapper,
                               dalproductVendorMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>6c7aed2b685a9541273ff9b506cf2bc0</Hash>
</Codenesium>*/