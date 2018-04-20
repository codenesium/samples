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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/phoneNumberTypes")]
	[ApiVersion("1.0")]
	[Response]
	public class PhoneNumberTypeController: AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ServiceSettings settings,
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPhoneNumberType phoneNumberTypeManager
			)
			: base(settings,
			       logger,
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
    <Hash>01cd8127f03f2013c708010d3bd0f328</Hash>
</Codenesium>*/