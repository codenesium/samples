using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/specialOffers")]
        [ApiVersion("1.0")]
        public class SpecialOfferController: AbstractSpecialOfferController
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
    <Hash>07c36689a4161f1b1f937c52af1933d9</Hash>
</Codenesium>*/