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
    <Hash>1db095a835c0282450a44ac47cc555b3</Hash>
</Codenesium>*/