using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>c37fd5dece6f9a44f88c9913a55fa826</Hash>
</Codenesium>*/