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
	public class ChainStatusRepository: AbstractChainStatusRepository
	{
		public ChainStatusRepository(ILogger logger,
		                             DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>2d4d56fbcd036651c4d88dd97cb57e87</Hash>
</Codenesium>*/