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
			IBOLProductCategoryMapper bolProductCategoryMapper,
			IDALProductCategoryMapper dalProductCategoryMapper,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper)
			: base(logger,
			       mediator,
			       productCategoryRepository,
			       productCategoryModelValidator,
			       bolProductCategoryMapper,
			       dalProductCategoryMapper,
			       bolProductSubcategoryMapper,
			       dalProductSubcategoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fe4c299a44af9a1ec59538537ab6b29a</Hash>
</Codenesium>*/