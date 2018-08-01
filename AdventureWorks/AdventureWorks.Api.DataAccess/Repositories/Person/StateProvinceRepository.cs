using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class StateProvinceRepository : AbstractStateProvinceRepository, IStateProvinceRepository
	{
		public StateProvinceRepository(
			ILogger<StateProvinceRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5f8e5fd28ebd937a243a72e6bc2dd675</Hash>
</Codenesium>*/