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
	public partial class CallPersonRepository : AbstractCallPersonRepository, ICallPersonRepository
	{
		public CallPersonRepository(
			ILogger<CallPersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>53568347b695978b508f31be08d771dc</Hash>
</Codenesium>*/