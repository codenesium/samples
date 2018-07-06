using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/specialOffers")]
        [ApiController]
        [ApiVersion("1.0")]
        public class SpecialOfferController : AbstractSpecialOfferController
        {
                public SpecialOfferController(
                        ApiSettings settings,
                        ILogger<SpecialOfferController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpecialOfferService specialOfferService,
                        IApiSpecialOfferModelMapper specialOfferModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               specialOfferService,
                               specialOfferModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3e437cbc6e98c6b03f4a8a2fc9bea778</Hash>
</Codenesium>*/