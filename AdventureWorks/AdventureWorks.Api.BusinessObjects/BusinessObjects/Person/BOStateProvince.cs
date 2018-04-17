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
			IStateProvinceModelValidator stateProvinceModelValidator)
			: base(logger, stateProvinceRepository, stateProvinceModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cd9dbf0189d36bc0bdd09a549484d733</Hash>
</Codenesium>*/