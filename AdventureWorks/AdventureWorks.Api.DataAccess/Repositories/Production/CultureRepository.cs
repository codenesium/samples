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
	public partial class CultureRepository : AbstractCultureRepository, ICultureRepository
	{
		public CultureRepository(
			ILogger<CultureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8f1af31ca124875661633bdfdd246da5</Hash>
</Codenesium>*/