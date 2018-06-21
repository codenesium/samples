using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class VenueRepository : AbstractVenueRepository, IVenueRepository
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
    <Hash>4731d8f79bfdbd20c0bcbf2f7955e020</Hash>
</Codenesium>*/