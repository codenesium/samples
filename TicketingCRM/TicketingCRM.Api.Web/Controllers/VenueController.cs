using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/venues")]
        [ApiVersion("1.0")]
        public class VenueController : AbstractVenueController
        {
                public VenueController(
                        ApiSettings settings,
                        ILogger<VenueController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVenueService venueService,
                        IApiVenueModelMapper venueModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               venueService,
                               venueModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>02c4b759687d2084fcb5752f31d99213</Hash>
</Codenesium>*/