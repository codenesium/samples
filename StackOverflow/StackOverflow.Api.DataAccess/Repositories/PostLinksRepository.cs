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
	public partial class PostLinksRepository : AbstractPostLinksRepository, IPostLinksRepository
	{
		public PostLinksRepository(
			ILogger<PostLinksRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>653fc7655820e57b7ea4e17f9b8cf2dc</Hash>
</Codenesium>*/