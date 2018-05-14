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
			IApiLinkStatusModelValidator linkStatusModelValidator)
			: base(logger, linkStatusRepository, linkStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a0762532fe4e5a99a688aec6a891a23f</Hash>
</Codenesium>*/