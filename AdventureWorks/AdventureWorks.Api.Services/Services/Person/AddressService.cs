using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class AddressService : AbstractAddressService, IAddressService
	{
		public AddressService(
			ILogger<IAddressRepository> logger,
			IAddressRepository addressRepository,
			IApiAddressRequestModelValidator addressModelValidator,
			IBOLAddressMapper boladdressMapper,
			IDALAddressMapper daladdressMapper,
			IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
			)
			: base(logger,
			       addressRepository,
			       addressModelValidator,
			       boladdressMapper,
			       daladdressMapper,
			       bolBusinessEntityAddressMapper,
			       dalBusinessEntityAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dcc6eb9ce3f357612a8d5beab1f9c693</Hash>
</Codenesium>*/