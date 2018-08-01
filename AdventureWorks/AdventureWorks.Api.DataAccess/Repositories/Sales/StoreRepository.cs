using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class StoreRepository : AbstractStoreRepository, IStoreRepository
	{
		public StoreRepository(
			ILogger<StoreRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f78b3fc76a6fb424391ef26981407a2f</Hash>
</Codenesium>*/