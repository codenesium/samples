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
	public class LinkRepository: AbstractLinkRepository
	{
		public LinkRepository(ILogger logger,
		                      DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>f3d63fb547f22031aeafb5f8abcbfef1</Hash>
</Codenesium>*/