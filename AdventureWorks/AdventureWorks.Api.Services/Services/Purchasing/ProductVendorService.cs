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
        public partial class ProductVendorService : AbstractProductVendorService, IProductVendorService
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
    <Hash>94f795b8917c49947df39927ecbafb9b</Hash>
</Codenesium>*/