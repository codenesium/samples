using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class StoreService : AbstractStoreService, IStoreService
	{
		public StoreService(
			ILogger<IStoreRepository> logger,
			IMediator mediator,
			IStoreRepository storeRepository,
			IApiStoreServerRequestModelValidator storeModelValidator,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base(logger,
			       mediator,
			       storeRepository,
			       storeModelValidator,
			       bolStoreMapper,
			       dalStoreMapper,
			       bolCustomerMapper,
			       dalCustomerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c030f28bd3039335e8a5b42cde72fcfd</Hash>
</Codenesium>*/