using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial class MessengerRepository : AbstractMessengerRepository, IMessengerRepository
	{
		public MessengerRepository(
			ILogger<MessengerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3cfbbb72df5b0fb2c5dd63e64421cb1c</Hash>
</Codenesium>*/