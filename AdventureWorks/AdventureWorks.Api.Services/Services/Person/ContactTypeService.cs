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
			IDALContactTypeMapper dalContactTypeMapper)
			: base(logger,
			       mediator,
			       contactTypeRepository,
			       contactTypeModelValidator,
			       dalContactTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0b970e40dd4e5da611ee6626736c5a28</Hash>
</Codenesium>*/