using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial class CommentService : AbstractCommentService, ICommentService
	{
		public CommentService(
			ILogger<ICommentRepository> logger,
			ICommentRepository commentRepository,
			IApiCommentRequestModelValidator commentModelValidator,
			IBOLCommentMapper bolcommentMapper,
			IDALCommentMapper dalcommentMapper)
			: base(logger,
			       commentRepository,
			       commentModelValidator,
			       bolcommentMapper,
			       dalcommentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>88f3d207faaf072e6397ca3dabae2c82</Hash>
</Codenesium>*/