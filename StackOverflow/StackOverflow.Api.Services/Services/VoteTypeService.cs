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
			IDALVoteTypeMapper dalvoteTypeMapper)
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
    <Hash>c6ab36efba9a6460ae4c2b718bf0d9c1</Hash>
</Codenesium>*/