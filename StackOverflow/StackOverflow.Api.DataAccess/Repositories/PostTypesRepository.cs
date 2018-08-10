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
    <Hash>27ff0d15fb4bfed933628b29e130def2</Hash>
</Codenesium>*/