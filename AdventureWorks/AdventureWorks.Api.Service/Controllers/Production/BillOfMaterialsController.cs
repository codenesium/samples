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
	[Route("api/billOfMaterials")]
	[ApiVersion("1.0")]
	[Response]
	public class BillOfMaterialsController: AbstractBillOfMaterialsController
	{
		public BillOfMaterialsController(
			ServiceSettings settings,
			ILogger<BillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBillOfMaterials billOfMaterialsManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       billOfMaterialsManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6b5dea47f15d2919c8759b7c1aec1113</Hash>
</Codenesium>*/