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
    <Hash>37ba36b794a0191568bb1e49cfc394d2</Hash>
</Codenesium>*/