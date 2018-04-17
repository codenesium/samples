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
			ILinkModelValidator linkModelValidator)
			: base(logger, linkRepository, linkModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cf8eb4c99a89b17098611550bc9d4734</Hash>
</Codenesium>*/