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
	public partial class CallStatuRepository : AbstractCallStatuRepository, ICallStatuRepository
	{
		public CallStatuRepository(
			ILogger<CallStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9395509a8a903f66c875373c4c17ea86</Hash>
</Codenesium>*/