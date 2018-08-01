using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>ef67d3cfe614519f09251e7038b4f542</Hash>
</Codenesium>*/