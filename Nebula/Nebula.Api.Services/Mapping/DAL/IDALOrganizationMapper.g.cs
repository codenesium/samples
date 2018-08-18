using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALOrganizationMapper
	{
		Organization MapBOToEF(
			BOOrganization bo);

		BOOrganization MapEFToBO(
			Organization efOrganization);

		List<BOOrganization> MapEFToBO(
			List<Organization> records);
	}
}

/*<Codenesium>
    <Hash>9b46692ea8f0909118bfb8569ffc8e68</Hash>
</Codenesium>*/