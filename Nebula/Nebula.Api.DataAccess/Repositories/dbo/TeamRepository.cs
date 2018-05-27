using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class TeamRepository: AbstractTeamRepository, ITeamRepository
	{
		public TeamRepository(
			IDALTeamMapper mapper,
			ILogger<TeamRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>bca992dac882fcb3cf970fbfb7edcd7d</Hash>
</Codenesium>*/