using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class VersionInfoService: AbstractVersionInfoService, IVersionInfoService
	{
		public VersionInfoService(
			ILogger<VersionInfoRepository> logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper BOLversionInfoMapper,
			IDALVersionInfoMapper DALversionInfoMapper)
			: base(logger, versionInfoRepository,
			       versionInfoModelValidator,
			       BOLversionInfoMapper,
			       DALversionInfoMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>df574b09b158f172f77e681c46218759</Hash>
</Codenesium>*/