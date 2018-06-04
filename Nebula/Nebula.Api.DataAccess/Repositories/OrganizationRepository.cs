using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class OrganizationRepository: AbstractOrganizationRepository, IOrganizationRepository
	{
		public OrganizationRepository(
			ILogger<OrganizationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c08d566541ed204a91e02987710fc998</Hash>
</Codenesium>*/