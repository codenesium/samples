using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class StateProvinceService: AbstractStateProvinceService, IStateProvinceService
	{
		public StateProvinceService(
			ILogger<StateProvinceRepository> logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper BOLstateProvinceMapper,
			IDALStateProvinceMapper DALstateProvinceMapper)
			: base(logger, stateProvinceRepository,
			       stateProvinceModelValidator,
			       BOLstateProvinceMapper,
			       DALstateProvinceMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>44ea2da7a7c9057bf5e7293f680209a3</Hash>
</Codenesium>*/