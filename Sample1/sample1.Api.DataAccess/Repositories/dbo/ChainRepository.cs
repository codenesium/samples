using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using sample1NS.Api.Contracts;

namespace sample1NS.Api.DataAccess
{
	public class ChainRepository: AbstractChainRepository
	{
		public ChainRepository(ILogger logger,
		                       DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>0cf695f509e65473e82d922d6ef4231b</Hash>
</Codenesium>*/