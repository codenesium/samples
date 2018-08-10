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
    <Hash>163a8114b7a4788d962917b94f224ac3</Hash>
</Codenesium>*/