using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Web
{
	[Route("api/versionInfoes")]
	[ApiVersion("1.0")]
	public class VersionInfoController: AbstractVersionInfoController
	{
		public VersionInfoController(
			ServiceSettings settings,
			ILogger<VersionInfoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVersionInfoService versionInfoService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       versionInfoService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>75aeb04b0947a4f4cbef79c0dbd3a5fe</Hash>
</Codenesium>*/