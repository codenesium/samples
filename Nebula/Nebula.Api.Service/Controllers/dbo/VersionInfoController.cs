using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
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
    <Hash>2eb9f4d5f12e7066af3c40cc0710a60e</Hash>
</Codenesium>*/