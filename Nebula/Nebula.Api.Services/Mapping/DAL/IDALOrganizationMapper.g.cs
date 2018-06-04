using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>15fba1f6e12189d3380e314493c115c0</Hash>
</Codenesium>*/