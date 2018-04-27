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
			IVersionInfoModelValidator versionInfoModelValidator)
			: base(logger, versionInfoRepository, versionInfoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>dcf51b04101629e501d5beb72c5b73c4</Hash>
</Codenesium>*/