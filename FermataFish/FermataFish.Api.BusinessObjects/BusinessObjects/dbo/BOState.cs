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
			IApiStateRequestModelValidator stateModelValidator,
			IBOLStateMapper stateMapper)
			: base(logger, stateRepository, stateModelValidator, stateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1c8532046f1854f8ee2b4ffe39f401d4</Hash>
</Codenesium>*/