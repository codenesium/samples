using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class BOVersionInfo: AbstractBOVersionInfo, IBOVersionInfo
	{
		public BOVersionInfo(
			ILogger<VersionInfoRepository> logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper versionInfoMapper)
			: base(logger, versionInfoRepository, versionInfoModelValidator, versionInfoMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3c18997ffdde2527937372a05d5fa149</Hash>
</Codenesium>*/