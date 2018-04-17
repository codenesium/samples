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
			ITeamModelValidator teamModelValidator)
			: base(logger, teamRepository, teamModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>36aa866591cdcae2f1897e1f7ed09efd</Hash>
</Codenesium>*/