using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class StoreRepository: AbstractStoreRepository, IStoreRepository
	{
		public StoreRepository(
			IObjectMapper mapper,
			ILogger<StoreRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>089dd779430100252d64cf5103571738</Hash>
</Codenesium>*/