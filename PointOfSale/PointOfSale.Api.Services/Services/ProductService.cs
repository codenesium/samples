using MediatR;
using Microsoft.Extensions.Logging;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;

namespace PointOfSaleNS.Api.Services
{
	public partial class ProductService : AbstractProductService, IProductService
	{
		public ProductService(
			ILogger<IProductRepository> logger,
			IMediator mediator,
			IProductRepository productRepository,
			IApiProductServerRequestModelValidator productModelValidator,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
			       productRepository,
			       productModelValidator,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8df194ef72cfb71b5d190e49f84e5941</Hash>
</Codenesium>*/