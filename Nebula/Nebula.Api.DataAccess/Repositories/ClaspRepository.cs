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
    <Hash>336de0c488a5c96935ce329d49cca9c2</Hash>
</Codenesium>*/