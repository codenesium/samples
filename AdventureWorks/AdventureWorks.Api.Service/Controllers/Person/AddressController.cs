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
	[Route("api/addresses")]
	public class AddressesController: AbstractAddressesController
	{
		public AddressesController(
			ILogger<AddressesController> logger,
			ApplicationContext context,
			IAddressRepository addressRepository,
			IAddressModelValidator addressModelValidator
			) : base(logger,
			         context,
			         addressRepository,
			         addressModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>35ffa87e66c1eb0bb2f31cd01df5ce94</Hash>
</Codenesium>*/