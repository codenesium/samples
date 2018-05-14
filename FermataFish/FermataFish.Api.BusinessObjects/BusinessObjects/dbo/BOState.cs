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
			IApiStateModelValidator stateModelValidator)
			: base(logger, stateRepository, stateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d48506eed65bfc22d58c6068d34aba18</Hash>
</Codenesium>*/