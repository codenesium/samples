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
	public partial class CallStatusRepository : AbstractCallStatusRepository, ICallStatusRepository
	{
		public CallStatusRepository(
			ILogger<CallStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1d8e9289c71b2cbcc3efff7c4736f148</Hash>
</Codenesium>*/