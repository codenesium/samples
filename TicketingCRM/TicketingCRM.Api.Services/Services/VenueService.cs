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
                        IDALVenueMapper dalvenueMapper

                        )
                        : base(logger,
                               venueRepository,
                               venueModelValidator,
                               bolvenueMapper,
                               dalvenueMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>1e4e6cc7745c74b7f0b449ed16f18956</Hash>
</Codenesium>*/