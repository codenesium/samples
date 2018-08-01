using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkLogRepository : AbstractLinkLogRepository, ILinkLogRepository
	{
		public LinkLogRepository(
			ILogger<LinkLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>54069dda31dbaaf74b3b95c3a15614e8</Hash>
</Codenesium>*/