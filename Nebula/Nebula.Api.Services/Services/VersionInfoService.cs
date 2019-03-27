using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class VersionInfoService : AbstractVersionInfoService, IVersionInfoService
	{
		public VersionInfoService(
			ILogger<IVersionInfoRepository> logger,
			IMediator mediator,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoServerRequestModelValidator versionInfoModelValidator,
			IDALVersionInfoMapper dalVersionInfoMapper)
			: base(logger,
			       mediator,
			       versionInfoRepository,
			       versionInfoModelValidator,
			       dalVersionInfoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>51923ef97a05f53388db946c04eec6ae</Hash>
</Codenesium>*/