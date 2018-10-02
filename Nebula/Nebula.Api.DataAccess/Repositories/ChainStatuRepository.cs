using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial class ChainStatuRepository : AbstractChainStatuRepository, IChainStatuRepository
	{
		public ChainStatuRepository(
			ILogger<ChainStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>35ae7266db21995710328ebcd411583d</Hash>
</Codenesium>*/