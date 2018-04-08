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
			) : base(logger,
			         transactionCoordinator,
			         billOfMaterialsRepository,
			         billOfMaterialsModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>61eb1f2d2f7a0a817b076d8ba53a614b</Hash>
</Codenesium>*/