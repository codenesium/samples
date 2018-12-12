using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace ESPIOTNS.Api.Services
{
	public partial class EfmigrationshistoryService : AbstractEfmigrationshistoryService, IEfmigrationshistoryService
	{
		public EfmigrationshistoryService(
			ILogger<IEfmigrationshistoryRepository> logger,
			IEfmigrationshistoryRepository efmigrationshistoryRepository,
			IApiEfmigrationshistoryServerRequestModelValidator efmigrationshistoryModelValidator,
			IBOLEfmigrationshistoryMapper bolEfmigrationshistoryMapper,
			IDALEfmigrationshistoryMapper dalEfmigrationshistoryMapper)
			: base(logger,
			       efmigrationshistoryRepository,
			       efmigrationshistoryModelValidator,
			       bolEfmigrationshistoryMapper,
			       dalEfmigrationshistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>89ac2f10c148ffbc1a6ca4524c2a9c43</Hash>
</Codenesium>*/