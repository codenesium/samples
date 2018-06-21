using Codenesium.DataConversionExtensions;
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
    <Hash>0eaacb83077023a4e57f4c6738047114</Hash>
</Codenesium>*/