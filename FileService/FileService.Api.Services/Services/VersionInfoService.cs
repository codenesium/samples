using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
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
    <Hash>4e1dd209aa8eea9dc4888db373ed2d31</Hash>
</Codenesium>*/