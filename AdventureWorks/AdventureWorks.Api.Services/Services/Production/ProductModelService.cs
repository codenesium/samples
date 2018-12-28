using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductModelService : AbstractProductModelService, IProductModelService
	{
		public ProductModelService(
			ILogger<IProductModelRepository> logger,
			IMediator mediator,
			IProductModelRepository productModelRepository,
			IApiProductModelServerRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper bolProductModelMapper,
			IDALProductModelMapper dalProductModelMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
			       productModelRepository,
			       productModelModelValidator,
			       bolProductModelMapper,
			       dalProductModelMapper,
			       bolProductMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>aac9d0299ef02422bf3e485844a6c6e1</Hash>
</Codenesium>*/