using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostLinkRepository : AbstractPostLinkRepository, IPostLinkRepository
	{
		public PostLinkRepository(
			ILogger<PostLinkRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1c3255524ed4e3b973a5d9179e773682</Hash>
</Codenesium>*/