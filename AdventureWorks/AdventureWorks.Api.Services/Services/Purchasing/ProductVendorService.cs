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
                        ILogger<IProductVendorRepository> logger,
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
    <Hash>586cf1964bf4cc1c035ac15e2b13b43f</Hash>
</Codenesium>*/