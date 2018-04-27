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
			IVersionInfoModelValidator versionInfoModelValidator)
			: base(logger, versionInfoRepository, versionInfoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>0cdedbc454e8326b4495840520a7c306</Hash>
</Codenesium>*/