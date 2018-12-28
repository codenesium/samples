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
			IBOLAddressTypeMapper bolAddressTypeMapper,
			IDALAddressTypeMapper dalAddressTypeMapper)
			: base(logger,
			       mediator,
			       addressTypeRepository,
			       addressTypeModelValidator,
			       bolAddressTypeMapper,
			       dalAddressTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3252f5e22e990f02b7c5a21ac858616e</Hash>
</Codenesium>*/