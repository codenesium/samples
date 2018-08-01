using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/eventRelatedDocuments")]
	[ApiController]
	[ApiVersion("1.0")]
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
    <Hash>26546b67a04e2e0e1ab96b7ff9ec8cfa</Hash>
</Codenesium>*/