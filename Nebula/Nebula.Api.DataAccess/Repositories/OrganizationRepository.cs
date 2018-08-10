using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>3adaacd186be48c37e0a6fc837ad3032</Hash>
</Codenesium>*/