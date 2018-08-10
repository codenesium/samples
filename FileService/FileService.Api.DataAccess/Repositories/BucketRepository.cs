using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public partial class BucketRepository : AbstractBucketRepository, IBucketRepository
	{
		public BucketRepository(
			ILogger<BucketRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f2e5d84c91bb751e9a5357154dd39116</Hash>
</Codenesium>*/