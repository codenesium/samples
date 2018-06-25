using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class VendorRepository : AbstractVendorRepository, IVendorRepository
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
    <Hash>d23828f04cc3241f22ca2dbf28486324</Hash>
</Codenesium>*/