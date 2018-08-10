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
	public partial class UnitMeasureRepository : AbstractUnitMeasureRepository, IUnitMeasureRepository
	{
		public UnitMeasureRepository(
			ILogger<UnitMeasureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ca097e6bd7f8dcbcb7e89ff5e5b405e2</Hash>
</Codenesium>*/