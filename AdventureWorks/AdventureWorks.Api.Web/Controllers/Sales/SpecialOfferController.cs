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
    <Hash>b854773742110bd10ad3a639e31cf7fd</Hash>
</Codenesium>*/