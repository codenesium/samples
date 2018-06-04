using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class OrganizationService: AbstractOrganizationService, IOrganizationService
	{
		public OrganizationService(
			ILogger<OrganizationRepository> logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper BOLorganizationMapper,
			IDALOrganizationMapper DALorganizationMapper)
			: base(logger, organizationRepository,
			       organizationModelValidator,
			       BOLorganizationMapper,
			       DALorganizationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e3f0c3be72a7d228f7c7cf63ab0fe0cb</Hash>
</Codenesium>*/