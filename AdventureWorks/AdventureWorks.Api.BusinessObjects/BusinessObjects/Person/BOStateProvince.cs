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
			IApiStateProvinceRequestModelValidator stateProvinceModelValidator,
			IBOLStateProvinceMapper stateProvinceMapper)
			: base(logger, stateProvinceRepository, stateProvinceModelValidator, stateProvinceMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b1e28ef96a563ee46f21f8e79153791b</Hash>
</Codenesium>*/