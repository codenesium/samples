using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class LinkLogRepository: AbstractLinkLogRepository, ILinkLogRepository
	{
		public LinkLogRepository(
			ILogger<LinkLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>486159488d2b2d2aff3499c716d28cb4</Hash>
</Codenesium>*/