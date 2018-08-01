using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkRepository : AbstractLinkRepository, ILinkRepository
	{
		public LinkRepository(
			ILogger<LinkRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7d4d73e587ef4407e5532b80f8dd9402</Hash>
</Codenesium>*/