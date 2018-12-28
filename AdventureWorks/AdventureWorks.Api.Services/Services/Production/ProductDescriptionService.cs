using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductDescriptionService : AbstractProductDescriptionService, IProductDescriptionService
	{
		public ProductDescriptionService(
			ILogger<IProductDescriptionRepository> logger,
			IMediator mediator,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionServerRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper bolProductDescriptionMapper,
			IDALProductDescriptionMapper dalProductDescriptionMapper)
			: base(logger,
			       mediator,
			       productDescriptionRepository,
			       productDescriptionModelValidator,
			       bolProductDescriptionMapper,
			       dalProductDescriptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cccd1f4648ebc1a8d234237a939b96bf</Hash>
</Codenesium>*/