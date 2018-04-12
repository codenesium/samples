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
	[Route("api/billOfMaterials")]
	public class BillOfMaterialsController: AbstractBillOfMaterialsController
	{
		public BillOfMaterialsController(
			ILogger<BillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IBillOfMaterialsModelValidator billOfMaterialsModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       billOfMaterialsRepository,
			       billOfMaterialsModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d0cfb561fe5220e51e81106a9c1b2924</Hash>
</Codenesium>*/