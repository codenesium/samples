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
    <Hash>43b72c76524ff5b7ff4d3278a5c5f573</Hash>
</Codenesium>*/