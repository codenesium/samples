using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALAdminMapper
	{
		Admin MapBOToEF(
			BOAdmin bo);

		BOAdmin MapEFToBO(
			Admin efAdmin);

		List<BOAdmin> MapEFToBO(
			List<Admin> records);
	}
}

/*<Codenesium>
    <Hash>104eb670a12fb65547250fc1b2f4c1db</Hash>
</Codenesium>*/