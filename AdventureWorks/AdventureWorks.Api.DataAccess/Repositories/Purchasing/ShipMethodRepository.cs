using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ShipMethodRepository : AbstractShipMethodRepository, IShipMethodRepository
        {
                public ShipMethodRepository(
                        ILogger<ShipMethodRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f1962e31c4a64a066b99e60e08018cee</Hash>
</Codenesium>*/