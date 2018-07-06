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
        [Route("api/specialOfferProducts")]
        [ApiController]
        [ApiVersion("1.0")]
        public class SpecialOfferProductController : AbstractSpecialOfferProductController
        {
                public SpecialOfferProductController(
                        ApiSettings settings,
                        ILogger<SpecialOfferProductController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpecialOfferProductService specialOfferProductService,
                        IApiSpecialOfferProductModelMapper specialOfferProductModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               specialOfferProductService,
                               specialOfferProductModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c48d305ea9397870b4c200109765f0e5</Hash>
</Codenesium>*/