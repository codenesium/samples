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
			IApiAddressModelValidator addressModelValidator)
			: base(logger, addressRepository, addressModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f4147fc89d7c857ae76b4b424c65b855</Hash>
</Codenesium>*/