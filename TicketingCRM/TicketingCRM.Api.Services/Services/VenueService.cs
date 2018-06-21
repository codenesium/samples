using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class VenueService : AbstractVenueService, IVenueService
        {
                public VenueService(
                        ILogger<IVenueRepository> logger,
                        IVenueRepository venueRepository,
                        IApiVenueRequestModelValidator venueModelValidator,
                        IBOLVenueMapper bolvenueMapper,
                        IDALVenueMapper dalvenueMapper
                        )
                        : base(logger,
                               venueRepository,
                               venueModelValidator,
                               bolvenueMapper,
                               dalvenueMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>980e8cce19a42b20a79bbc2aaec8a292</Hash>
</Codenesium>*/