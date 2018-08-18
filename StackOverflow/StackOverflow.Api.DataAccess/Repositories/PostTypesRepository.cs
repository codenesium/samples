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
    <Hash>d23135d86169dec89d98337ed543f6ad</Hash>
</Codenesium>*/