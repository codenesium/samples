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
			ApplicationContext context,
			IProductDocumentRepository productDocumentRepository,
			IProductDocumentModelValidator productDocumentModelValidator
			) : base(logger,
			         context,
			         productDocumentRepository,
			         productDocumentModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f6ee5a26d4b8e13164d03c590a5587b7</Hash>
</Codenesium>*/