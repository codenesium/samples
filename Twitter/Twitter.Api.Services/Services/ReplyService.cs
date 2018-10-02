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
	public partial class ReplyService : AbstractReplyService, IReplyService
	{
		public ReplyService(
			ILogger<IReplyRepository> logger,
			IReplyRepository replyRepository,
			IApiReplyRequestModelValidator replyModelValidator,
			IBOLReplyMapper bolreplyMapper,
			IDALReplyMapper dalreplyMapper
			)
			: base(logger,
			       replyRepository,
			       replyModelValidator,
			       bolreplyMapper,
			       dalreplyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2daee6ff4affd2e07b8e387fd48b01d3</Hash>
</Codenesium>*/