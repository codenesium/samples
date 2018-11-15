using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductSubcategoryService : AbstractProductSubcategoryService, IProductSubcategoryService
	{
		public ProductSubcategoryService(
			ILogger<IProductSubcategoryRepository> logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryServerRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       productSubcategoryRepository,
			       productSubcategoryModelValidator,
			       bolProductSubcategoryMapper,
			       dalProductSubcategoryMapper,
			       bolProductMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5122247bb28dbd47c00e9cd516ff76dd</Hash>
</Codenesium>*/