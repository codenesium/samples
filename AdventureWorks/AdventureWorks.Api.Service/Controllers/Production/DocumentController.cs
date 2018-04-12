using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/documents")]
	public class DocumentController: AbstractDocumentController
	{
		public DocumentController(
			ILogger<DocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentRepository documentRepository,
			IDocumentModelValidator documentModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       documentRepository,
			       documentModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c52c3592a7a292bc56402ac168049cc6</Hash>
</Codenesium>*/