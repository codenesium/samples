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
			ApplicationContext context,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator
			) : base(logger,
			         context,
			         phoneNumberTypeRepository,
			         phoneNumberTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0bf7c095d111d1e145deb12147700a8d</Hash>
</Codenesium>*/