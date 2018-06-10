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
        public class VenueService: AbstractVenueService, IVenueService
        {
                public VenueService(
                        ILogger<VenueRepository> logger,
                        IVenueRepository venueRepository,
                        IApiVenueRequestModelValidator venueModelValidator,
                        IBOLVenueMapper bolvenueMapper,
                        IDALVenueMapper dalvenueMapper)
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
    <Hash>3076b2076f67ec971208f69c8bde0344</Hash>
</Codenesium>*/