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
			IApiVersionInfoModelValidator versionInfoModelValidator)
			: base(logger, versionInfoRepository, versionInfoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f5c0c5e0fcf0f0b6b55cd97f0fe93069</Hash>
</Codenesium>*/