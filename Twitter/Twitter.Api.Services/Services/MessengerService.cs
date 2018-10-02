using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class MessengerService : AbstractMessengerService, IMessengerService
	{
		public MessengerService(
			ILogger<IMessengerRepository> logger,
			IMessengerRepository messengerRepository,
			IApiMessengerRequestModelValidator messengerModelValidator,
			IBOLMessengerMapper bolmessengerMapper,
			IDALMessengerMapper dalmessengerMapper
			)
			: base(logger,
			       messengerRepository,
			       messengerModelValidator,
			       bolmessengerMapper,
			       dalmessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eaac9dd72f24164ad01faf328e82ffbf</Hash>
</Codenesium>*/