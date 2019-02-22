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
	public partial class CallDispositionRepository : AbstractCallDispositionRepository, ICallDispositionRepository
	{
		public CallDispositionRepository(
			ILogger<CallDispositionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7c379ecfa36c4333312e887efc1316fd</Hash>
</Codenesium>*/