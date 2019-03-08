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
    <Hash>d1bba4aec3e4ef06a381ed75dda988ff</Hash>
</Codenesium>*/