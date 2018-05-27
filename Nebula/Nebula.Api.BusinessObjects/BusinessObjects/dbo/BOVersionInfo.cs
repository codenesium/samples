using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
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
    <Hash>ff6a2322a0ae4edc5c2dbbe3629e710c</Hash>
</Codenesium>*/