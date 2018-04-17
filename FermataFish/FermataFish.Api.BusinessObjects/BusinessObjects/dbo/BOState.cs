using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOState: AbstractBOState, IBOState
	{
		public BOState(
			ILogger<StateRepository> logger,
			IStateRepository stateRepository,
			IStateModelValidator stateModelValidator)
			: base(logger, stateRepository, stateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e92e21eb6bd8b4e1bc401a248f0f0330</Hash>
</Codenesium>*/