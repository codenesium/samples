using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class TagsRepository : AbstractTagsRepository, ITagsRepository
	{
		public TagsRepository(
			ILogger<TagsRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>706d4cf15e6bc701b477b1b36aaeb5ae</Hash>
</Codenesium>*/