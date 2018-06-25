using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ShipMethodRepository : AbstractShipMethodRepository, IShipMethodRepository
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
    <Hash>550a9c9a9e42081fe36495735e4bfd7d</Hash>
</Codenesium>*/