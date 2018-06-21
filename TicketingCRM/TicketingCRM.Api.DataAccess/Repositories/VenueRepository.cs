using Codenesium.DataConversionExtensions;
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
    <Hash>8dbe57118b2c5a3e065556c25716df81</Hash>
</Codenesium>*/