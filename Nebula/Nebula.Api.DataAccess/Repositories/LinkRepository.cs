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
    <Hash>1bfd7c72f5616f31f40d25cd09c57624</Hash>
</Codenesium>*/