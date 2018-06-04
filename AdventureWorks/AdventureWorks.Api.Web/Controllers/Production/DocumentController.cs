using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/documents")]
	[ApiVersion("1.0")]
	public class DocumentController: AbstractDocumentController
	{
		public DocumentController(
			ServiceSettings settings,
			ILogger<DocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentService documentService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       documentService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7bf40b53b994e8b7d415b5070066f397</Hash>
</Codenesium>*/