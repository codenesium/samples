using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class BucketRepository: AbstractBucketRepository, IBucketRepository
	{
		public BucketRepository(
			IDALBucketMapper mapper,
			ILogger<BucketRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>423ee6c55b51b4296c627da0e8545dbc</Hash>
</Codenesium>*/