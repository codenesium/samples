using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>95e1023a23f1f10759bf5ed621011025</Hash>
</Codenesium>*/