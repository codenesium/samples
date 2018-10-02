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
	public partial class ReplyRepository : AbstractReplyRepository, IReplyRepository
	{
		public ReplyRepository(
			ILogger<ReplyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1688b353effeae0a5ae3e09773417ec3</Hash>
</Codenesium>*/