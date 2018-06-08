using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ShipMethodRepository: AbstractShipMethodRepository, IShipMethodRepository
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
    <Hash>2320451e7baa2a6ad2bb4dda614b16de</Hash>
</Codenesium>*/