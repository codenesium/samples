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
	public class BOLink:AbstractBOLink, IBOLink
	{
		public BOLink(
			ILogger<LinkRepository> logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper linkMapper)
			: base(logger, linkRepository, linkModelValidator, linkMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>db594f297271b8f4041540ea3caaeacd</Hash>
</Codenesium>*/