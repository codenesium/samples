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
	public partial class VoteTypeService : AbstractVoteTypeService, IVoteTypeService
	{
		public VoteTypeService(
			ILogger<IVoteTypeRepository> logger,
			IVoteTypeRepository voteTypeRepository,
			IApiVoteTypeRequestModelValidator voteTypeModelValidator,
			IBOLVoteTypeMapper bolvoteTypeMapper,
			IDALVoteTypeMapper dalvoteTypeMapper
			)
			: base(logger,
			       voteTypeRepository,
			       voteTypeModelValidator,
			       bolvoteTypeMapper,
			       dalvoteTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>040e04e6d72a00ec694e7e55f371dfde</Hash>
</Codenesium>*/