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
			IAddressModelValidator addressModelValidator)
			: base(logger, addressRepository, addressModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6193878e7b1897ed75dcb03fcfad4506</Hash>
</Codenesium>*/