using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class StateProvinceRepository: AbstractStateProvinceRepository, IStateProvinceRepository
	{
		public StateProvinceRepository(
			IDALStateProvinceMapper mapper,
			ILogger<StateProvinceRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>36a87df1e8d493bdedb04b4bcf46df18</Hash>
</Codenesium>*/