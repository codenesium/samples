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
			ApplicationContext context,
			IAddressTypeRepository addressTypeRepository,
			IAddressTypeModelValidator addressTypeModelValidator
			) : base(logger,
			         context,
			         addressTypeRepository,
			         addressTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>acda3a18efef27cc10f2f8bcf74188c4</Hash>
</Codenesium>*/