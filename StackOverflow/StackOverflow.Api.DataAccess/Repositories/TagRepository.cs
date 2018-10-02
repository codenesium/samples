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
	public partial class TagRepository : AbstractTagRepository, ITagRepository
	{
		public TagRepository(
			ILogger<TagRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3fc6be57c619a8fcc0a4ed5c7d81d89e</Hash>
</Codenesium>*/