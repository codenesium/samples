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
			IDALTagMapper daltagMapper)
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
    <Hash>129da4407ee6677d7b8c315bfa21762b</Hash>
</Codenesium>*/