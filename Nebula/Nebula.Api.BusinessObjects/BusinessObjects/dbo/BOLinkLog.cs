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
	public class BOLinkLog: AbstractBOLinkLog, IBOLinkLog
	{
		public BOLinkLog(
			ILogger<LinkLogRepository> logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper linkLogMapper)
			: base(logger, linkLogRepository, linkLogModelValidator, linkLogMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>53aa8d59ed06d374a59c23fbc2893a22</Hash>
</Codenesium>*/