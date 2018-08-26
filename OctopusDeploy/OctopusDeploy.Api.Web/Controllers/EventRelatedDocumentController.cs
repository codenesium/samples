using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/eventRelatedDocuments")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class EventRelatedDocumentController : AbstractEventRelatedDocumentController
	{
		public EventRelatedDocumentController(
			ApiSettings settings,
			ILogger<EventRelatedDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventRelatedDocumentService eventRelatedDocumentService,
			IApiEventRelatedDocumentModelMapper eventRelatedDocumentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       eventRelatedDocumentService,
			       eventRelatedDocumentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5afc74ded8301170a3ae6f8cb491df31</Hash>
</Codenesium>*/