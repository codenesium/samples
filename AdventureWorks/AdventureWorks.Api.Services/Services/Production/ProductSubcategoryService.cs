using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductSubcategoryService : AbstractProductSubcategoryService, IProductSubcategoryService
	{
		public ProductSubcategoryService(
			ILogger<IProductSubcategoryRepository> logger,
			IMediator mediator,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryServerRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
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
    <Hash>22406c5230d441257226b4708299e447</Hash>
</Codenesium>*/