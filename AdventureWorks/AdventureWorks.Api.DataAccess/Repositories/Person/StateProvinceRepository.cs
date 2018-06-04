using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class StateProvinceRepository: AbstractStateProvinceRepository, IStateProvinceRepository
	{
		public StateProvinceRepository(
			ILogger<StateProvinceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>59b3a94c32dee818509457023aa07106</Hash>
</Codenesium>*/