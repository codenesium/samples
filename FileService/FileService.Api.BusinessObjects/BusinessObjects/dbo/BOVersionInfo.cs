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
			IApiVersionInfoModelValidator versionInfoModelValidator)
			: base(logger, versionInfoRepository, versionInfoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>91926ba08eebd69b51c7a70c62a416be</Hash>
</Codenesium>*/