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
	public partial class VotesService : AbstractVotesService, IVotesService
	{
		public VotesService(
			ILogger<IVotesRepository> logger,
			IVotesRepository votesRepository,
			IApiVotesRequestModelValidator votesModelValidator,
			IBOLVotesMapper bolvotesMapper,
			IDALVotesMapper dalvotesMapper
			)
			: base(logger,
			       votesRepository,
			       votesModelValidator,
			       bolvotesMapper,
			       dalvotesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a5dde4199847077b7fa5810510606675</Hash>
</Codenesium>*/