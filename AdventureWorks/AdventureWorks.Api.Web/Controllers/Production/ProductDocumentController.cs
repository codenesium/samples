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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productDocuments")]
	[ApiVersion("1.0")]
	public class ProductDocumentController: AbstractProductDocumentController
	{
		public ProductDocumentController(
			ServiceSettings settings,
			ILogger<ProductDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDocumentService productDocumentService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productDocumentService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a0896142f8aaa9410b5de29d1561cf0d</Hash>
</Codenesium>*/