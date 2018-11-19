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

	public class ColumnSameAsFKTableController : AbstractColumnSameAsFKTableController
	{
		public ColumnSameAsFKTableController(
			ApiSettings settings,
			ILogger<ColumnSameAsFKTableController> logger,
			ITransactionCoordinator transactionCoordinator,
			IColumnSameAsFKTableService columnSameAsFKTableService,
			IApiColumnSameAsFKTableServerModelMapper columnSameAsFKTableModelMapper
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
    <Hash>daa741466a22176f96b97edd4d1a7f38</Hash>
</Codenesium>*/