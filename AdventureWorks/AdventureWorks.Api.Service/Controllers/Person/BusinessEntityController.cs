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
			ApplicationContext context,
			IBusinessEntityRepository businessEntityRepository,
			IBusinessEntityModelValidator businessEntityModelValidator
			) : base(logger,
			         context,
			         businessEntityRepository,
			         businessEntityModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7d70e22607276ecb431943681dee8021</Hash>
</Codenesium>*/