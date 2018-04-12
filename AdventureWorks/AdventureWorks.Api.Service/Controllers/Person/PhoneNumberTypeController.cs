using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/phoneNumberTypes")]
	public class PhoneNumberTypeController: AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       phoneNumberTypeRepository,
			       phoneNumberTypeModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>61fd394b5bf9065779144346d9e78524</Hash>
</Codenesium>*/