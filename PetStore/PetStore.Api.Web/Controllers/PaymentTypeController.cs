using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStoreNS.Api.Web
{
        [Route("api/paymentTypes")]
        [ApiVersion("1.0")]
        public class PaymentTypeController : AbstractPaymentTypeController
        {
                public PaymentTypeController(
                        ApiSettings settings,
                        ILogger<PaymentTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPaymentTypeService paymentTypeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               paymentTypeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9e440e9718c37ec9299ec261e931a883</Hash>
</Codenesium>*/