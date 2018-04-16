using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/phoneNumberTypes")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PhoneNumberTypeFilter))]
	public class PhoneNumberTypeController: AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeRepository phoneNumberTypeRepository
			)
			: base(logger,
			       transactionCoordinator,
			       phoneNumberTypeRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2fca3774dcdc89e2018b65963c26ae9c</Hash>
</Codenesium>*/