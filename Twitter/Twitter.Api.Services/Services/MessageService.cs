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
			IDALMessengerMapper dalMessengerMapper)
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
    <Hash>1630a2d458ffcb23bc8059e462ed4de3</Hash>
</Codenesium>*/