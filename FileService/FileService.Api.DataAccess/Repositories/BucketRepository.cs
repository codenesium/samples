using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>33d181095f65fb8205be1a17fe4fe95e</Hash>
</Codenesium>*/