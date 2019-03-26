using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class AddressTypeService : AbstractAddressTypeService, IAddressTypeService
	{
		public AddressTypeService(
			ILogger<IAddressTypeRepository> logger,
			IMediator mediator,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeServerRequestModelValidator addressTypeModelValidator,
			IDALAddressTypeMapper dalAddressTypeMapper)
			: base(logger,
			       mediator,
			       addressTypeRepository,
			       addressTypeModelValidator,
			       dalAddressTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a3c5daeab2f642f869cfe2cb943e625c</Hash>
</Codenesium>*/