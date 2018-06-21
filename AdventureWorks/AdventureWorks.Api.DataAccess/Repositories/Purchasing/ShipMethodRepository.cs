using Codenesium.DataConversionExtensions;
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
    <Hash>bae59b54ded529676a94dc91f464405b</Hash>
</Codenesium>*/