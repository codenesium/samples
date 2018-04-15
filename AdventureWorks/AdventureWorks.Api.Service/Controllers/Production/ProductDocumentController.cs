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
	[Route("api/productDocuments")]
	[ApiVersion("1.0")]
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
    <Hash>8c1e50c455078b15c5696cf80e3ffd3c</Hash>
</Codenesium>*/