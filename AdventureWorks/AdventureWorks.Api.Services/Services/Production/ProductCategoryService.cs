using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductCategoryService : AbstractProductCategoryService, IProductCategoryService
	{
		public ProductCategoryService(
			ILogger<IProductCategoryRepository> logger,
			IMediator mediator,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryServerRequestModelValidator productCategoryModelValidator,
			IDALProductCategoryMapper dalProductCategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper)
			: base(logger,
			       mediator,
			       productCategoryRepository,
			       productCategoryModelValidator,
			       dalProductCategoryMapper,
			       dalProductSubcategoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6f591e4bd3027a53166706f413f32ffd</Hash>
</Codenesium>*/