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
using PetStoreNS.Api.BusinessObjects;

namespace PetStoreNS.Api.Service
{
	[Route("api/paymentTypes")]
	[ApiVersion("1.0")]
	[Response]
	public class PaymentTypeController: AbstractPaymentTypeController
	{
		public PaymentTypeController(
			ServiceSettings settings,
			ILogger<PaymentTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPaymentType paymentTypeManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       paymentTypeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d34736783b66b582fc7cbd4a543fed68</Hash>
</Codenesium>*/