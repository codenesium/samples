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
	[Route("api/productDocuments")]
	public class ProductDocumentsController: AbstractProductDocumentsController
	{
		public ProductDocumentsController(
			ILogger<ProductDocumentsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDocumentRepository productDocumentRepository,
			IProductDocumentModelValidator productDocumentModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productDocumentRepository,
			         productDocumentModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>21d15856a156a0138899936126f5cd8f</Hash>
</Codenesium>*/