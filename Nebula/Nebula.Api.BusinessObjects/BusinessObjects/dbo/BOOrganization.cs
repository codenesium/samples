using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOOrganization: AbstractBOOrganization, IBOOrganization
	{
		public BOOrganization(
			ILogger<OrganizationRepository> logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationModelValidator organizationModelValidator)
			: base(logger, organizationRepository, organizationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ae5b1fd5191d8fb149d2d25642e4c962</Hash>
</Codenesium>*/