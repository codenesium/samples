using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	[Route("api/sysdiagrams")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class SysdiagramController : AbstractSysdiagramController
	{
		public SysdiagramController(
			ApiSettings settings,
			ILogger<SysdiagramController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISysdiagramService sysdiagramService,
			IApiSysdiagramModelMapper sysdiagramModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       sysdiagramService,
			       sysdiagramModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9c35966129d1d3ae6df51656abe32801</Hash>
</Codenesium>*/