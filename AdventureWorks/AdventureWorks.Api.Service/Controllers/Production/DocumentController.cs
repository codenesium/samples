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
	public class DocumentsController: AbstractDocumentsController
	{
		public DocumentsController(
			ILogger<DocumentsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDocumentRepository documentRepository,
			IDocumentModelValidator documentModelValidator
			) : base(logger,
			         transactionCoordinator,
			         documentRepository,
			         documentModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b3451ccafb58a8ef11a0f6db1edc6cdf</Hash>
</Codenesium>*/