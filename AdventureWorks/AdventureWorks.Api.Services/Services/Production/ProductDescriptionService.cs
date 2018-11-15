using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductDescriptionService : AbstractProductDescriptionService, IProductDescriptionService
	{
		public ProductDescriptionService(
			ILogger<IProductDescriptionRepository> logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionServerRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper bolProductDescriptionMapper,
			IDALProductDescriptionMapper dalProductDescriptionMapper)
			: base(logger,
			       productDescriptionRepository,
			       productDescriptionModelValidator,
			       bolProductDescriptionMapper,
			       dalProductDescriptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5b06d1a72ed81f3cecbd7ed413e28db5</Hash>
</Codenesium>*/