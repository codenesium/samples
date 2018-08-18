using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial class ClaspRepository : AbstractClaspRepository, IClaspRepository
	{
		public ClaspRepository(
			ILogger<ClaspRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6639cb524d489bbe3bb2bfeda213bac1</Hash>
</Codenesium>*/