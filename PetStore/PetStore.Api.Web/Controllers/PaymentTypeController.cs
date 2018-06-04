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
    <Hash>2c3489763a0a722906d572650751d30a</Hash>
</Codenesium>*/