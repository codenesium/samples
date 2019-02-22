using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial class UnitRepository : AbstractUnitRepository, IUnitRepository
	{
		public UnitRepository(
			ILogger<UnitRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2b49a0dc6fe5e6838b9cac0f860e64af</Hash>
</Codenesium>*/