using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductCategoryService : AbstractProductCategoryService, IProductCategoryService
	{
		public ProductCategoryService(
			ILogger<IProductCategoryRepository> logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryServerRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper bolProductCategoryMapper,
			IDALProductCategoryMapper dalProductCategoryMapper,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper)
			: base(logger,
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
    <Hash>ba006a14ec6d5b3bd9c9175f69ace1d5</Hash>
</Codenesium>*/