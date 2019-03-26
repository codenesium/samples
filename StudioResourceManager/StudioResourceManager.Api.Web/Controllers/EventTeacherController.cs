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
	[Route("api/eventTeachers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class EventTeacherController : AbstractEventTeacherController
	{
		public EventTeacherController(
			ApiSettings settings,
			ILogger<EventTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventTeacherService eventTeacherService,
			IApiEventTeacherServerModelMapper eventTeacherModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       eventTeacherService,
			       eventTeacherModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e513d3f59b8692501e59024cbd478960</Hash>
</Codenesium>*/