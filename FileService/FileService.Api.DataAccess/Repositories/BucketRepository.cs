using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
	public class BucketRepository: AbstractBucketRepository, IBucketRepository
	{
		public BucketRepository(
			ILogger<BucketRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>bbac7ea2bb843a22a59080770e9a5318</Hash>
</Codenesium>*/