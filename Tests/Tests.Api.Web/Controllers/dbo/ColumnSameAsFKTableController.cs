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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/columnSameAsFKTables")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ColumnSameAsFKTableController : AbstractColumnSameAsFKTableController
	{
		public ColumnSameAsFKTableController(
			ApiSettings settings,
			ILogger<ColumnSameAsFKTableController> logger,
			ITransactionCoordinator transactionCoordinator,
			IColumnSameAsFKTableService columnSameAsFKTableService,
			IApiColumnSameAsFKTableModelMapper columnSameAsFKTableModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       columnSameAsFKTableService,
			       columnSameAsFKTableModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b7504aed59e11c2cee646a1165413594</Hash>
</Codenesium>*/