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
                        IDALVendorMapper dalvendorMapper)
                        : base(logger,
                               vendorRepository,
                               vendorModelValidator,
                               bolvendorMapper,
                               dalvendorMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1378d3c90b6f42a2f1833c164ea1b97a</Hash>
</Codenesium>*/