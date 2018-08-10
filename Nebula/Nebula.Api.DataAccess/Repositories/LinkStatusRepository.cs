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
    <Hash>5f9111574b5c83db342bc6f9679618e2</Hash>
</Codenesium>*/