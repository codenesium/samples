using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
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
    <Hash>facc9bb34b317637c6ed491b610effbe</Hash>
</Codenesium>*/