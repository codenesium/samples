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
    <Hash>dec5e7ea2a5b9caa3746227fb81ecc36</Hash>
</Codenesium>*/