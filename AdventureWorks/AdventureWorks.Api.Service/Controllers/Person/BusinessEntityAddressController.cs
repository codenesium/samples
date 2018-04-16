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
	[Route("api/businessEntityAddresses")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(BusinessEntityAddressFilter))]
	public class BusinessEntityAddressController: AbstractBusinessEntityAddressController
	{
		public BusinessEntityAddressController(
			ILogger<BusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBusinessEntityAddressRepository businessEntityAddressRepository
			)
			: base(logger,
			       transactionCoordinator,
			       businessEntityAddressRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cac39c767b0bf30702499743bd228fcd</Hash>
</Codenesium>*/