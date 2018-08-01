using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>22981bf3fde168a7b7a05f0c6ffe73fa</Hash>
</Codenesium>*/