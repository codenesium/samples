using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class StateService: AbstractStateService, IStateService
	{
		public StateService(
			ILogger<StateRepository> logger,
			IStateRepository stateRepository,
			IApiStateRequestModelValidator stateModelValidator,
			IBOLStateMapper BOLstateMapper,
			IDALStateMapper DALstateMapper)
			: base(logger, stateRepository,
			       stateModelValidator,
			       BOLstateMapper,
			       DALstateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>cfd4efa442bd0ae0379945068807c4da</Hash>
</Codenesium>*/