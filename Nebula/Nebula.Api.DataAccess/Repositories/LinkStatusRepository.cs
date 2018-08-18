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
    <Hash>b8219fd8b64233f137c0a0170cdd1417</Hash>
</Codenesium>*/