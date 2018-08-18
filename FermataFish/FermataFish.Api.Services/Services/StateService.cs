using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class StateService : AbstractStateService, IStateService
	{
		public StateService(
			ILogger<IStateRepository> logger,
			IStateRepository stateRepository,
			IApiStateRequestModelValidator stateModelValidator,
			IBOLStateMapper bolstateMapper,
			IDALStateMapper dalstateMapper,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper
			)
			: base(logger,
			       stateRepository,
			       stateModelValidator,
			       bolstateMapper,
			       dalstateMapper,
			       bolStudioMapper,
			       dalStudioMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c44e3355c3e42ec5851a61c392e3169c</Hash>
</Codenesium>*/