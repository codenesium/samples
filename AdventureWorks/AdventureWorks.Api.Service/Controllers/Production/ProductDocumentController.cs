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
	public class ProductDocumentController: AbstractProductDocumentController
	{
		public ProductDocumentController(
			ILogger<ProductDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDocumentRepository productDocumentRepository,
			IProductDocumentModelValidator productDocumentModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productDocumentRepository,
			       productDocumentModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>feb47fdc9c433b73cc18e3c00163a60a</Hash>
</Codenesium>*/