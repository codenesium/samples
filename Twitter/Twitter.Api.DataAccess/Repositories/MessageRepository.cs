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
	public partial class MessageRepository : AbstractMessageRepository, IMessageRepository
	{
		public MessageRepository(
			ILogger<MessageRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>634074c49631398f9646a6deb925a7ff</Hash>
</Codenesium>*/