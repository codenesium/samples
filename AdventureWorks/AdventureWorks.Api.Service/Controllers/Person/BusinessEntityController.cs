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
	[Route("api/businessEntities")]
	public class BusinessEntitiesController: AbstractBusinessEntitiesController
	{
		public BusinessEntitiesController(
			ILogger<BusinessEntitiesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityRepository businessEntityRepository,
			IBusinessEntityModelValidator businessEntityModelValidator
			) : base(logger,
			         transactionCoordinator,
			         businessEntityRepository,
			         businessEntityModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6a6e597ee4007a6d1795435dd2721572</Hash>
</Codenesium>*/