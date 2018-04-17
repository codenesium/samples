using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/phoneNumberTypes")]
	[ApiVersion("1.0")]
	public class PhoneNumberTypeController: AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPhoneNumberType phoneNumberTypeManager
			)
			: base(logger,
			       transactionCoordinator,
			       phoneNumberTypeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>063a998b859fe50698eddd99684b6c94</Hash>
</Codenesium>*/