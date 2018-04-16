using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/documents")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(DocumentFilter))]
	public class DocumentController: AbstractDocumentController
	{
		public DocumentController(
			ILogger<DocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentRepository documentRepository
			)
			: base(logger,
			       transactionCoordinator,
			       documentRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>58aa83137b7a9b433841ca96b213edb2</Hash>
</Codenesium>*/