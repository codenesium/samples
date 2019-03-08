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
	public partial class CommentsRepository : AbstractCommentsRepository, ICommentsRepository
	{
		public CommentsRepository(
			ILogger<CommentsRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>22dc421903441ced328c79a6ad30a663</Hash>
</Codenesium>*/