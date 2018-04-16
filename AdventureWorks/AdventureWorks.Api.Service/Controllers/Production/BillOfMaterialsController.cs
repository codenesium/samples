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
	[Route("api/billOfMaterials")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(BillOfMaterialsFilter))]
	public class BillOfMaterialsController: AbstractBillOfMaterialsController
	{
		public BillOfMaterialsController(
			ILogger<BillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialsRepository billOfMaterialsRepository
			)
			: base(logger,
			       transactionCoordinator,
			       billOfMaterialsRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>962871556d71146b99130698e377b15b</Hash>
</Codenesium>*/