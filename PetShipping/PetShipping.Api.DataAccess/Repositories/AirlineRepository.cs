using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class AirlineRepository : AbstractAirlineRepository, IAirlineRepository
        {
                public AirlineRepository(
                        ILogger<AirlineRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1560cf3768f8a59f46e19813224f6a21</Hash>
</Codenesium>*/