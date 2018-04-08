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
	[Route("api/addressTypes")]
	public class AddressTypesController: AbstractAddressTypesController
	{
		public AddressTypesController(
			ILogger<AddressTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAddressTypeRepository addressTypeRepository,
			IAddressTypeModelValidator addressTypeModelValidator
			) : base(logger,
			         transactionCoordinator,
			         addressTypeRepository,
			         addressTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>84a96ef490c16da19259d18bca84c7ea</Hash>
</Codenesium>*/