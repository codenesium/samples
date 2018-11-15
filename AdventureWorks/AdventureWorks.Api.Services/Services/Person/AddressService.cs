using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class AddressService : AbstractAddressService, IAddressService
	{
		public AddressService(
			ILogger<IAddressRepository> logger,
			IAddressRepository addressRepository,
			IApiAddressServerRequestModelValidator addressModelValidator,
			IBOLAddressMapper bolAddressMapper,
			IDALAddressMapper dalAddressMapper)
			: base(logger,
			       addressRepository,
			       addressModelValidator,
			       bolAddressMapper,
			       dalAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5ef5e0b3db77b1963cf4f8e4d3880689</Hash>
</Codenesium>*/