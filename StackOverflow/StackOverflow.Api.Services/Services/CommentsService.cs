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
	public partial class CommentsService : AbstractCommentsService, ICommentsService
	{
		public CommentsService(
			ILogger<ICommentsRepository> logger,
			ICommentsRepository commentsRepository,
			IApiCommentsRequestModelValidator commentsModelValidator,
			IBOLCommentsMapper bolcommentsMapper,
			IDALCommentsMapper dalcommentsMapper
			)
			: base(logger,
			       commentsRepository,
			       commentsModelValidator,
			       bolcommentsMapper,
			       dalcommentsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>79ced3ea8034b9563ec256857287d262</Hash>
</Codenesium>*/