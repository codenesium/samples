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
	public partial class TagsService : AbstractTagsService, ITagsService
	{
		public TagsService(
			ILogger<ITagsRepository> logger,
			ITagsRepository tagsRepository,
			IApiTagsRequestModelValidator tagsModelValidator,
			IBOLTagsMapper boltagsMapper,
			IDALTagsMapper daltagsMapper
			)
			: base(logger,
			       tagsRepository,
			       tagsModelValidator,
			       boltagsMapper,
			       daltagsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fbd3f34097fdbecf394a246c46d5e66b</Hash>
</Codenesium>*/