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
	[Route("api/billOfMaterials")]
	[ApiVersion("1.0")]
	public class BillOfMaterialsController: AbstractBillOfMaterialsController
	{
		public BillOfMaterialsController(
			ILogger<BillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBillOfMaterials billOfMaterialsManager
			)
			: base(logger,
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
    <Hash>dc1f320facab63c82df117d8870172c5</Hash>
</Codenesium>*/