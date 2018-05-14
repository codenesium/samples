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
			IApiLinkModelValidator linkModelValidator)
			: base(logger, linkRepository, linkModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>811267f5facaf6b4ed4485cc34b8e927</Hash>
</Codenesium>*/