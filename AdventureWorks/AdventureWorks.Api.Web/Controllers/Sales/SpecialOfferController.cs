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
                        ISpecialOfferService specialOfferService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               specialOfferService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ff9d34c636fe0608c75a0c8c6705ef6e</Hash>
</Codenesium>*/