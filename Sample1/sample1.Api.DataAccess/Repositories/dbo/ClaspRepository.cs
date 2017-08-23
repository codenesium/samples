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
	public class ClaspRepository: AbstractClaspRepository
	{
		public ClaspRepository(ILogger logger,
		                       DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>662bcb8ca7baec917638c41a8c425866</Hash>
</Codenesium>*/