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
			IDALProductDescriptionMapper dalProductDescriptionMapper)
			: base(logger,
			       mediator,
			       productDescriptionRepository,
			       productDescriptionModelValidator,
			       dalProductDescriptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f6096f86c867afd872a48099c7f94a1f</Hash>
</Codenesium>*/