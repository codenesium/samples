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
	[Route("api/productModelProductDescriptionCultures")]
	public class ProductModelProductDescriptionCulturesController: AbstractProductModelProductDescriptionCulturesController
	{
		public ProductModelProductDescriptionCulturesController(
			ILogger<ProductModelProductDescriptionCulturesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productModelProductDescriptionCultureRepository,
			         productModelProductDescriptionCultureModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8547a8c65aeff765ccd70960834059ee</Hash>
</Codenesium>*/