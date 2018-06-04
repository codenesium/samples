using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class AddressService: AbstractAddressService, IAddressService
	{
		public AddressService(
			ILogger<AddressRepository> logger,
			IAddressRepository addressRepository,
			IApiAddressRequestModelValidator addressModelValidator,
			IBOLAddressMapper BOLaddressMapper,
			IDALAddressMapper DALaddressMapper)
			: base(logger, addressRepository,
			       addressModelValidator,
			       BOLaddressMapper,
			       DALaddressMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>77ceaf4a1555ed29f7c5af372b4163dc</Hash>
</Codenesium>*/