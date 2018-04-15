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
    <Hash>968890d656c1ce4094ddb5959262cc3c</Hash>
</Codenesium>*/