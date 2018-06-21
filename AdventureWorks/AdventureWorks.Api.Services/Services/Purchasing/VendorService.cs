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
    <Hash>babf815f310444e8e36f3c3324b0caa7</Hash>
</Codenesium>*/