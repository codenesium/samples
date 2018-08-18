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
    <Hash>7198c7b146d80ee2f453d1a742315ef3</Hash>
</Codenesium>*/