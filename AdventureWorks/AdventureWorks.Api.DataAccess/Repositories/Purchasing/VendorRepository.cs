using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class VendorRepository : AbstractVendorRepository, IVendorRepository
        {
                public VendorRepository(
                        ILogger<VendorRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>74d82691cf9f8bdace8b16dfd29bea26</Hash>
</Codenesium>*/