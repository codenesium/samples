using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOAddress: AbstractBOAddress, IBOAddress
	{
		public BOAddress(
			ILogger<AddressRepository> logger,
			IAddressRepository addressRepository,
			IApiAddressRequestModelValidator addressModelValidator,
			IBOLAddressMapper addressMapper)
			: base(logger, addressRepository, addressModelValidator, addressMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e1487e717b64da021a5a98afb8f2ca99</Hash>
</Codenesium>*/