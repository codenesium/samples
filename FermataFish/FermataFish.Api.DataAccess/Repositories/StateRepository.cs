using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class StateRepository: AbstractStateRepository, IStateRepository
	{
		public StateRepository(
			ILogger<StateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>49a52ccf19bbb7a7425ccc2470c546b8</Hash>
</Codenesium>*/