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
			IApiLinkLogModelValidator linkLogModelValidator)
			: base(logger, linkLogRepository, linkLogModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ade1ec4a4dff06ebd781da49564e7efa</Hash>
</Codenesium>*/