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
        public class ProductVendorService : AbstractProductVendorService, IProductVendorService
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
                               dalproductVendorMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>95c8c3d137f70ff8a795a33528c9ffff</Hash>
</Codenesium>*/