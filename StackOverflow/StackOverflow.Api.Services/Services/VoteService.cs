using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial class VoteService : AbstractVoteService, IVoteService
	{
		public VoteService(
			ILogger<IVoteRepository> logger,
			IVoteRepository voteRepository,
			IApiVoteRequestModelValidator voteModelValidator,
			IBOLVoteMapper bolvoteMapper,
			IDALVoteMapper dalvoteMapper
			)
			: base(logger,
			       voteRepository,
			       voteModelValidator,
			       bolvoteMapper,
			       dalvoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ac32cc56881164335c8bdb2b6f1fda0</Hash>
</Codenesium>*/