using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>5164613bba2fc88fa66c5f9b041f98aa</Hash>
</Codenesium>*/