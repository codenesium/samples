using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class OrganizationRepository : AbstractOrganizationRepository, IOrganizationRepository
	{
		public OrganizationRepository(
			ILogger<OrganizationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>34c95bb3982bffc8d810065e49b6e373</Hash>
</Codenesium>*/