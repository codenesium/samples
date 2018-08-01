using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IDALOrganizationMapper
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
    <Hash>3b8547d6f4a66b261ae7f071cf0f5498</Hash>
</Codenesium>*/