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
using FileServiceNS.Api.BusinessObjects;

namespace FileServiceNS.Api.Service
{
	[Route("api/versionInfoes")]
	[ApiVersion("1.0")]
	[Response]
	public class VersionInfoController: AbstractVersionInfoController
	{
		public VersionInfoController(
			ServiceSettings settings,
			ILogger<VersionInfoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOVersionInfo versionInfoManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       versionInfoManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dde06030ea71264b8f8de25f64f8f142</Hash>
</Codenesium>*/