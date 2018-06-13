using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/venues")]
        [ApiVersion("1.0")]
        public class VenueController: AbstractVenueController
        {
                public VenueController(
                        ServiceSettings settings,
                        ILogger<VenueController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVenueService venueService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               venueService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9d6e631d5991309ead613dc27c8e27ea</Hash>
</Codenesium>*/