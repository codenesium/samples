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
using System.Threading.Tasks;

namespace PetStoreNS.Api.Web
{
	[Route("api/paymentTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PaymentTypeController : AbstractPaymentTypeController
	{
		public PaymentTypeController(
			ApiSettings settings,
			ILogger<PaymentTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPaymentTypeService paymentTypeService,
			IApiPaymentTypeModelMapper paymentTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       paymentTypeService,
			       paymentTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c185da2e33967f5bf408d13f16397927</Hash>
</Codenesium>*/