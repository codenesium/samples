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
	public class PhoneNumberTypesController: AbstractPhoneNumberTypesController
	{
		public PhoneNumberTypesController(
			ILogger<PhoneNumberTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator
			) : base(logger,
			         transactionCoordinator,
			         phoneNumberTypeRepository,
			         phoneNumberTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>24c7b3796d42fc08cf689091cba9137f</Hash>
</Codenesium>*/