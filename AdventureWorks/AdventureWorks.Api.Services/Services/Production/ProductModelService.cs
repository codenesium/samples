using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductModelService : AbstractProductModelService, IProductModelService
	{
		public ProductModelService(
			ILogger<IProductModelRepository> logger,
			IProductModelRepository productModelRepository,
			IApiProductModelServerRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper bolProductModelMapper,
			IDALProductModelMapper dalProductModelMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base(logger,
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
    <Hash>a4860a52b2244d741d60640e6c391df0</Hash>
</Codenesium>*/