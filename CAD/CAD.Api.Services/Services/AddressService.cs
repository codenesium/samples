using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class AddressService : AbstractAddressService, IAddressService
	{
		public AddressService(
			ILogger<IAddressRepository> logger,
			IMediator mediator,
			IAddressRepository addressRepository,
			IApiAddressServerRequestModelValidator addressModelValidator,
			IDALAddressMapper dalAddressMapper,
			IDALCallMapper dalCallMapper)
			: base(logger,
			       mediator,
			       addressRepository,
			       addressModelValidator,
			       dalAddressMapper,
			       dalCallMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e95be5c1a2060a5d2ca95fc4107c5e3b</Hash>
</Codenesium>*/