using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ContactTypeService : AbstractContactTypeService, IContactTypeService
	{
		public ContactTypeService(
			ILogger<IContactTypeRepository> logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeServerRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolContactTypeMapper,
			IDALContactTypeMapper dalContactTypeMapper)
			: base(logger,
			       contactTypeRepository,
			       contactTypeModelValidator,
			       bolContactTypeMapper,
			       dalContactTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>773af6ee08455067e380bac1ecd11c34</Hash>
</Codenesium>*/