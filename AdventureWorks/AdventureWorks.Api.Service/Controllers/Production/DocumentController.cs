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
			ApplicationContext context,
			IDocumentRepository documentRepository,
			IDocumentModelValidator documentModelValidator
			) : base(logger,
			         context,
			         documentRepository,
			         documentModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b72b156567cf627f571109f7a069e5ba</Hash>
</Codenesium>*/