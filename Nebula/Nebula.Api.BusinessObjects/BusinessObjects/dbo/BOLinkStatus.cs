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
	public class BOLinkStatus: AbstractBOLinkStatus, IBOLinkStatus
	{
		public BOLinkStatus(
			ILogger<LinkStatusRepository> logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusRequestModelValidator linkStatusModelValidator,
			IBOLLinkStatusMapper linkStatusMapper)
			: base(logger, linkStatusRepository, linkStatusModelValidator, linkStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1835d8e5abd1afe1171d6d72590cee62</Hash>
</Codenesium>*/