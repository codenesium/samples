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
	public partial class VoteTypeRepository : AbstractVoteTypeRepository, IVoteTypeRepository
	{
		public VoteTypeRepository(
			ILogger<VoteTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>159139b9ba5d0d39a570f708dc09f03e</Hash>
</Codenesium>*/