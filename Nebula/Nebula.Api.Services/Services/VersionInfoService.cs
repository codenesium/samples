using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class VersionInfoService : AbstractVersionInfoService, IVersionInfoService
	{
		public VersionInfoService(
			ILogger<IVersionInfoRepository> logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper bolversionInfoMapper,
			IDALVersionInfoMapper dalversionInfoMapper
			)
			: base(logger,
			       versionInfoRepository,
			       versionInfoModelValidator,
			       bolversionInfoMapper,
			       dalversionInfoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>368bd3694b2591f7578cd9b14bf6f2f5</Hash>
</Codenesium>*/