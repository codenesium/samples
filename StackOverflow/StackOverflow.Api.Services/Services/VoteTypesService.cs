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
	public partial class VoteTypesService : AbstractVoteTypesService, IVoteTypesService
	{
		public VoteTypesService(
			ILogger<IVoteTypesRepository> logger,
			IVoteTypesRepository voteTypesRepository,
			IApiVoteTypesRequestModelValidator voteTypesModelValidator,
			IBOLVoteTypesMapper bolvoteTypesMapper,
			IDALVoteTypesMapper dalvoteTypesMapper
			)
			: base(logger,
			       voteTypesRepository,
			       voteTypesModelValidator,
			       bolvoteTypesMapper,
			       dalvoteTypesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>127b8c195bca95ecfb1d5fbe3bf73eb6</Hash>
</Codenesium>*/