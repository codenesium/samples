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
	public partial class ErrorLogRepository : AbstractErrorLogRepository, IErrorLogRepository
	{
		public ErrorLogRepository(
			ILogger<ErrorLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6337f7272bc51263da83b37b78412bec</Hash>
</Codenesium>*/