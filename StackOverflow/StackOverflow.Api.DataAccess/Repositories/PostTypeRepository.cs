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
	public partial class PostTypeRepository : AbstractPostTypeRepository, IPostTypeRepository
	{
		public PostTypeRepository(
			ILogger<PostTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>90c602c0dc5d724d958f2f8b89d33912</Hash>
</Codenesium>*/