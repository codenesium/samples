using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial class LikeRepository : AbstractLikeRepository, ILikeRepository
	{
		public LikeRepository(
			ILogger<LikeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5467f8d746f2a0922cf4b3b83d4c03b9</Hash>
</Codenesium>*/