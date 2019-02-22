using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	[Route("api/callAssignments")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallAssignmentController : AbstractCallAssignmentController
	{
		public CallAssignmentController(
			ApiSettings settings,
			ILogger<CallAssignmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallAssignmentService callAssignmentService,
			IApiCallAssignmentServerModelMapper callAssignmentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callAssignmentService,
			       callAssignmentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>192952a88967e51abdd390590bd4cdd6</Hash>
</Codenesium>*/