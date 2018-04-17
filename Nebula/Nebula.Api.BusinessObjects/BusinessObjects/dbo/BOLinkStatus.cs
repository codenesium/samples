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
			ILinkStatusModelValidator linkStatusModelValidator)
			: base(logger, linkStatusRepository, linkStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d010a5ddec47300180260a6e882ea868</Hash>
</Codenesium>*/