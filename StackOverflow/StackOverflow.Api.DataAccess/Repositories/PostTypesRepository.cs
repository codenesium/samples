using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostTypesRepository : AbstractPostTypesRepository, IPostTypesRepository
	{
		public PostTypesRepository(
			ILogger<PostTypesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9b8a662c2fd73cbbd182cc2c2cdcbc3d</Hash>
</Codenesium>*/