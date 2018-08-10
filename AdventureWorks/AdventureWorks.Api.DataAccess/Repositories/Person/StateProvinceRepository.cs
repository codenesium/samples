using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>b59688628046a37b9151638fc6873847</Hash>
</Codenesium>*/