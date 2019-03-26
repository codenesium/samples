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
			IDALProductSubcategoryMapper dalProductSubcategoryMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
			       mediator,
			       productSubcategoryRepository,
			       productSubcategoryModelValidator,
			       dalProductSubcategoryMapper,
			       dalProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7aad35889a6a955a299af9f41ce7fa94</Hash>
</Codenesium>*/