using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOStateProvince: AbstractBOStateProvince, IBOStateProvince
	{
		public BOStateProvince(
			ILogger<StateProvinceRepository> logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceModelValidator stateProvinceModelValidator)
			: base(logger, stateProvinceRepository, stateProvinceModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d4d32bbacd40a8ec2c7bd5dbd163e151</Hash>
</Codenesium>*/