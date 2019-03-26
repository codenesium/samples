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
			IDALProductModelMapper dalProductModelMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
			       productModelRepository,
			       productModelModelValidator,
			       dalProductModelMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8fd34157f033b3ab553dd5747a437c43</Hash>
</Codenesium>*/