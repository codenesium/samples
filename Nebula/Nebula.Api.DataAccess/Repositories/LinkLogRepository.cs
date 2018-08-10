using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>9eaf9f952ea2be3459d99e4403d3f733</Hash>
</Codenesium>*/