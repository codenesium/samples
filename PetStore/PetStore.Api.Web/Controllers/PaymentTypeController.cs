using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web
{
        [Route("api/paymentTypes")]
        [ApiVersion("1.0")]
        public class PaymentTypeController: AbstractPaymentTypeController
        {
                public PaymentTypeController(
                        ServiceSettings settings,
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
    <Hash>9006d2c54ac989c0ce2e84bcfc6b4cd2</Hash>
</Codenesium>*/