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
        public class VendorService : AbstractVendorService, IVendorService
        {
                public VendorService(
                        ILogger<IVendorRepository> logger,
                        IVendorRepository vendorRepository,
                        IApiVendorRequestModelValidator vendorModelValidator,
                        IBOLVendorMapper bolvendorMapper,
                        IDALVendorMapper dalvendorMapper,
                        IBOLProductVendorMapper bolProductVendorMapper,
                        IDALProductVendorMapper dalProductVendorMapper,
                        IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper
                        )
                        : base(logger,
                               vendorRepository,
                               vendorModelValidator,
                               bolvendorMapper,
                               dalvendorMapper,
                               bolProductVendorMapper,
                               dalProductVendorMapper,
                               bolPurchaseOrderHeaderMapper,
                               dalPurchaseOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>387eb027d2c9b25baf96ead8eab5ed9a</Hash>
</Codenesium>*/