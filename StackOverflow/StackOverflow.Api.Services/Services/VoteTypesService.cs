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
    <Hash>6023bc944c4030cf29d59db8946fcf81</Hash>
</Codenesium>*/