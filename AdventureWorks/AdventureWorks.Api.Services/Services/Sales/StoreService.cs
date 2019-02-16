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
			IDALStoreMapper dalStoreMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base(logger,
			       mediator,
			       storeRepository,
			       storeModelValidator,
			       dalStoreMapper,
			       dalCustomerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e5fc6dd4cb34ba17ba919c6d5a60c223</Hash>
</Codenesium>*/