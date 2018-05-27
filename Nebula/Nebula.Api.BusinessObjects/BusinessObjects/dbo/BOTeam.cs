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
			IApiTeamRequestModelValidator teamModelValidator,
			IBOLTeamMapper teamMapper)
			: base(logger, teamRepository, teamModelValidator, teamMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>704ba2ba88dc3ce432eddb52e4183e8e</Hash>
</Codenesium>*/