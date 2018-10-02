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
	public partial class TagService : AbstractTagService, ITagService
	{
		public TagService(
			ILogger<ITagRepository> logger,
			ITagRepository tagRepository,
			IApiTagRequestModelValidator tagModelValidator,
			IBOLTagMapper boltagMapper,
			IDALTagMapper daltagMapper
			)
			: base(logger,
			       tagRepository,
			       tagModelValidator,
			       boltagMapper,
			       daltagMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>74eb13295d97c8c95460f74bbae08db2</Hash>
</Codenesium>*/