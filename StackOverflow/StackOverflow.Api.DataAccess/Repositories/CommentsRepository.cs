using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>0f6149324a00bbbb3ded0afa831e48fd</Hash>
</Codenesium>*/