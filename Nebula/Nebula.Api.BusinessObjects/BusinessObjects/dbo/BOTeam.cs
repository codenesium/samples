using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOTeam:AbstractBOTeam, IBOTeam
	{
		public BOTeam(
			ILogger<TeamRepository> logger,
			ITeamRepository teamRepository,
			IApiTeamModelValidator teamModelValidator)
			: base(logger, teamRepository, teamModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d27b8ad3bb7941304c056731b2a3db5f</Hash>
</Codenesium>*/