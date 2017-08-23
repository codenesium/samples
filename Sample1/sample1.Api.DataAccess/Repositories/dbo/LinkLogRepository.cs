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
	public class LinkLogRepository: AbstractLinkLogRepository
	{
		public LinkLogRepository(ILogger logger,
		                         DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>b4c57133959686f72ae72181d77b110d</Hash>
</Codenesium>*/