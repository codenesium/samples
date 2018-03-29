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
	[Route("api/businessEntityAddresses")]
	public class BusinessEntityAddressesController: AbstractBusinessEntityAddressesController
	{
		public BusinessEntityAddressesController(
			ILogger<BusinessEntityAddressesController> logger,
			ApplicationContext context,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IBusinessEntityAddressModelValidator businessEntityAddressModelValidator
			) : base(logger,
			         context,
			         businessEntityAddressRepository,
			         businessEntityAddressModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>50f49e04ef1cccbf8e9d5469070b4022</Hash>
</Codenesium>*/