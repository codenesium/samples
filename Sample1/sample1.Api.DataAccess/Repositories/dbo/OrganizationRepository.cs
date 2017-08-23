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
	public class OrganizationRepository: AbstractOrganizationRepository
	{
		public OrganizationRepository(ILogger logger,
		                              DbContext context) : base(logger,context)
		{}
	}
}

/*<Codenesium>
    <Hash>905abe61e6b02fc1e5dc5453f2640ba6</Hash>
</Codenesium>*/