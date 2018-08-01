using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkStatusRepository : AbstractLinkStatusRepository, ILinkStatusRepository
	{
		public LinkStatusRepository(
			ILogger<LinkStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>81412b051174d1d1c2d9d13a39a3f45f</Hash>
</Codenesium>*/