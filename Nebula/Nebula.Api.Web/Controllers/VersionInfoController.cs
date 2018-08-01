using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Web
{
	[Route("api/versionInfoes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class VersionInfoController : AbstractVersionInfoController
	{
		public VersionInfoController(
			ApiSettings settings,
			ILogger<VersionInfoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVersionInfoService versionInfoService,
			IApiVersionInfoModelMapper versionInfoModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       versionInfoService,
			       versionInfoModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0529f21e8659aea973a66640f9441929</Hash>
</Codenesium>*/