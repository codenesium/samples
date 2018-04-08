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
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IBusinessEntityAddressModelValidator businessEntityAddressModelValidator
			) : base(logger,
			         transactionCoordinator,
			         businessEntityAddressRepository,
			         businessEntityAddressModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fc79335ba515fedfdfff392ca95b2df5</Hash>
</Codenesium>*/