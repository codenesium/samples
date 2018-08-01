using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class VotesRepository : AbstractVotesRepository, IVotesRepository
	{
		public VotesRepository(
			ILogger<VotesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>299620714613761b4f8e865ddbda2145</Hash>
</Codenesium>*/