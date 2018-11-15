using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class AddressTypeService : AbstractAddressTypeService, IAddressTypeService
	{
		public AddressTypeService(
			ILogger<IAddressTypeRepository> logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeServerRequestModelValidator addressTypeModelValidator,
			IBOLAddressTypeMapper bolAddressTypeMapper,
			IDALAddressTypeMapper dalAddressTypeMapper)
			: base(logger,
			       addressTypeRepository,
			       addressTypeModelValidator,
			       bolAddressTypeMapper,
			       dalAddressTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a495d7998f9335d4ecdcaca9fb02db70</Hash>
</Codenesium>*/