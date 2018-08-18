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
    <Hash>da1294de547871403be725f4ee1ea3ed</Hash>
</Codenesium>*/