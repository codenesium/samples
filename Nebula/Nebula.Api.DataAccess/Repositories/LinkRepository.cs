using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class LinkRepository: AbstractLinkRepository, ILinkRepository
	{
		public LinkRepository(
			ILogger<LinkRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>445f7315477c7ca27daa3e0124343608</Hash>
</Codenesium>*/