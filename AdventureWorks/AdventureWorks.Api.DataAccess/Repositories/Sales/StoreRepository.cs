using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>96d6fe5d34e60335c527349ededddbb2</Hash>
</Codenesium>*/