using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class StateRepository : AbstractStateRepository, IStateRepository
	{
		public StateRepository(
			ILogger<StateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>486cf7f7030ea78ef99aab805e1d42b0</Hash>
</Codenesium>*/