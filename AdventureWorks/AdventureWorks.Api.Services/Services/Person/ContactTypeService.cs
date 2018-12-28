using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ContactTypeService : AbstractContactTypeService, IContactTypeService
	{
		public ContactTypeService(
			ILogger<IContactTypeRepository> logger,
			IMediator mediator,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeServerRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolContactTypeMapper,
			IDALContactTypeMapper dalContactTypeMapper)
			: base(logger,
			       mediator,
			       contactTypeRepository,
			       contactTypeModelValidator,
			       bolContactTypeMapper,
			       dalContactTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ca9304e6ed284934b9696e5752653590</Hash>
</Codenesium>*/