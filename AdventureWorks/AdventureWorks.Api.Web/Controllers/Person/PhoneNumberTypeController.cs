using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/phoneNumberTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PhoneNumberTypeController : AbstractPhoneNumberTypeController
	{
		public PhoneNumberTypeController(
			ApiSettings settings,
			ILogger<PhoneNumberTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPhoneNumberTypeService phoneNumberTypeService,
			IApiPhoneNumberTypeServerModelMapper phoneNumberTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       phoneNumberTypeService,
			       phoneNumberTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7a615245e9a5b5fa1644b0fd79284195</Hash>
</Codenesium>*/