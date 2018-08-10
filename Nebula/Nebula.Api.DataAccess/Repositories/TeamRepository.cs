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
	public partial class TeamRepository : AbstractTeamRepository, ITeamRepository
	{
		public TeamRepository(
			ILogger<TeamRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>837bac3bf2a2463d2af7d62b0ccf4df9</Hash>
</Codenesium>*/