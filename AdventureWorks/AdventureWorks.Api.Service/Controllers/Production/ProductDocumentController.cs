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
	[Route("api/productDocuments")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class ProductDocumentController: AbstractProductDocumentController
	{
		public ProductDocumentController(
			ILogger<ProductDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductDocument productDocumentManager
			)
			: base(logger,
			       transactionCoordinator,
			       productDocumentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8ee6ad57d54195e3e9ee54f723ee889d</Hash>
</Codenesium>*/