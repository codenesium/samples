using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class OrganizationRepository: AbstractOrganizationRepository, IOrganizationRepository
	{
		public OrganizationRepository(
			IDALOrganizationMapper mapper,
			ILogger<OrganizationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>94277b0ccb3db9c68d6c8fee0535d775</Hash>
</Codenesium>*/