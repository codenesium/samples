using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class VersionInfoService : AbstractVersionInfoService, IVersionInfoService
	{
		public VersionInfoService(
			ILogger<IVersionInfoRepository> logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoServerRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper bolVersionInfoMapper,
			IDALVersionInfoMapper dalVersionInfoMapper)
			: base(logger,
			       versionInfoRepository,
			       versionInfoModelValidator,
			       bolVersionInfoMapper,
			       dalVersionInfoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7f992f6e445fc2f6f3fb3a3eb1a67cc7</Hash>
</Codenesium>*/