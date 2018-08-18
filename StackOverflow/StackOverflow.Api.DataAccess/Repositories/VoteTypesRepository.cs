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
	public partial class VoteTypesRepository : AbstractVoteTypesRepository, IVoteTypesRepository
	{
		public VoteTypesRepository(
			ILogger<VoteTypesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8e9e57418cdd3085651b8fcb784b9e8f</Hash>
</Codenesium>*/