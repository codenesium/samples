using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class VenueRepository: AbstractVenueRepository, IVenueRepository
        {
                public VenueRepository(
                        ILogger<VenueRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ddb2a28c1af267613b1e96a43b862efb</Hash>
</Codenesium>*/