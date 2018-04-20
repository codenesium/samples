using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productDocuments")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductDocumentController: AbstractProductDocumentController
	{
		public ProductDocumentController(
			ServiceSettings settings,
			ILogger<ProductDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductDocument productDocumentManager
			)
			: base(settings,
			       logger,
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
    <Hash>9e3296a409980351f8afb3880741e909</Hash>
</Codenesium>*/