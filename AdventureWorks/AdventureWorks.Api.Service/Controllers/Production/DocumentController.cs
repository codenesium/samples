using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/documents")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class DocumentController: AbstractDocumentController
	{
		public DocumentController(
			ILogger<DocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODocument documentManager
			)
			: base(logger,
			       transactionCoordinator,
			       documentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4d4422ec9c98e0c161af8d434127fa60</Hash>
</Codenesium>*/