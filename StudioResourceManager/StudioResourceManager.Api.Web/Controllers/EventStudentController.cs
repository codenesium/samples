using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/eventStudents")]
	[ApiController]
	[ApiVersion("1.0")]

	public class EventStudentController : AbstractEventStudentController
	{
		public EventStudentController(
			ApiSettings settings,
			ILogger<EventStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventStudentService eventStudentService,
			IApiEventStudentServerModelMapper eventStudentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       eventStudentService,
			       eventStudentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6749afb70e8c17eb307c0dc70b8df7c1</Hash>
</Codenesium>*/