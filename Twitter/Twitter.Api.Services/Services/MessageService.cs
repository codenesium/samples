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
	public partial class MessageService : AbstractMessageService, IMessageService
	{
		public MessageService(
			ILogger<IMessageRepository> logger,
			IMessageRepository messageRepository,
			IApiMessageRequestModelValidator messageModelValidator,
			IBOLMessageMapper bolmessageMapper,
			IDALMessageMapper dalmessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper
			)
			: base(logger,
			       messageRepository,
			       messageModelValidator,
			       bolmessageMapper,
			       dalmessageMapper,
			       bolMessengerMapper,
			       dalMessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>249314e7fcacfdd0fcdf50f9e210699c</Hash>
</Codenesium>*/