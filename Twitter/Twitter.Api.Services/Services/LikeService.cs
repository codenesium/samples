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
	public partial class LikeService : AbstractLikeService, ILikeService
	{
		public LikeService(
			ILogger<ILikeRepository> logger,
			ILikeRepository likeRepository,
			IApiLikeRequestModelValidator likeModelValidator,
			IBOLLikeMapper bollikeMapper,
			IDALLikeMapper dallikeMapper
			)
			: base(logger,
			       likeRepository,
			       likeModelValidator,
			       bollikeMapper,
			       dallikeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f78a24c402f087175c999f06ada7ce72</Hash>
</Codenesium>*/