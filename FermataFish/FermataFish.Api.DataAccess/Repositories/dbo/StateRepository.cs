using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class StateRepository: AbstractStateRepository, IStateRepository
	{
		public StateRepository(
			IDALStateMapper mapper,
			ILogger<StateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c48d0c209d7104af217520892b0a3d30</Hash>
</Codenesium>*/