using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using sample1NS.Api.Contracts;

namespace sample1NS.Api.DataAccess
{
	public class TeamRepository: AbstractTeamRepository
	{
		public TeamRepository(ILogger logger,
		                      DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>fbd250a1de0f2c1656ebaaa624ec6efb</Hash>
</Codenesium>*/