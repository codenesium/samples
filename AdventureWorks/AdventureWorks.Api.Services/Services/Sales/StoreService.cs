using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class StoreService : AbstractStoreService, IStoreService
	{
		public StoreService(
			ILogger<IStoreRepository> logger,
			IStoreRepository storeRepository,
			IApiStoreServerRequestModelValidator storeModelValidator,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base(logger,
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
    <Hash>47a6b4186fa87e779a82df7288d307d5</Hash>
</Codenesium>*/