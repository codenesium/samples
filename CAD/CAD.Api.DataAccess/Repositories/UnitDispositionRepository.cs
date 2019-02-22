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
	public partial class UnitDispositionRepository : AbstractUnitDispositionRepository, IUnitDispositionRepository
	{
		public UnitDispositionRepository(
			ILogger<UnitDispositionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cfbd8a64bcc46cddd7ca5d02bcdb1758</Hash>
</Codenesium>*/