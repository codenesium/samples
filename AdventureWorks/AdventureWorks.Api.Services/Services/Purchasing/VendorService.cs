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
        public class VendorService: AbstractVendorService, IVendorService
        {
                public VendorService(
                        ILogger<VendorRepository> logger,
                        IVendorRepository vendorRepository,
                        IApiVendorRequestModelValidator vendorModelValidator,
                        IBOLVendorMapper bolvendorMapper,
                        IDALVendorMapper dalvendorMapper
                        ,
                        IBOLProductVendorMapper bolProductVendorMapper,
                        IDALProductVendorMapper dalProductVendorMapper
                        ,
                        IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper

                        )
                        : base(logger,
                               vendorRepository,
                               vendorModelValidator,
                               bolvendorMapper,
                               dalvendorMapper
                               ,
                               bolProductVendorMapper,
                               dalProductVendorMapper
                               ,
                               bolPurchaseOrderHeaderMapper,
                               dalPurchaseOrderHeaderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>afffb48747f52682ea826b968a42f2b2</Hash>
</Codenesium>*/