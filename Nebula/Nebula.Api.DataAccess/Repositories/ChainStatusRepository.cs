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
	public partial class ChainStatusRepository : AbstractChainStatusRepository, IChainStatusRepository
	{
		public ChainStatusRepository(
			ILogger<ChainStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>93e20ecd110c2a61e756891601e5d47d</Hash>
</Codenesium>*/