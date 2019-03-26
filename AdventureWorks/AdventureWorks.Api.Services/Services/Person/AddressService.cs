using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class AddressService : AbstractAddressService, IAddressService
	{
		public AddressService(
			ILogger<IAddressRepository> logger,
			IMediator mediator,
			IAddressRepository addressRepository,
			IApiAddressServerRequestModelValidator addressModelValidator,
			IDALAddressMapper dalAddressMapper)
			: base(logger,
			       mediator,
			       addressRepository,
			       addressModelValidator,
			       dalAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a159a5aa9ed52d738e1dd32b4ccbb42a</Hash>
</Codenesium>*/