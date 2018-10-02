using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALTicketStatuMapper
	{
		TicketStatu MapBOToEF(
			BOTicketStatu bo);

		BOTicketStatu MapEFToBO(
			TicketStatu efTicketStatu);

		List<BOTicketStatu> MapEFToBO(
			List<TicketStatu> records);
	}
}

/*<Codenesium>
    <Hash>ac9cda2950ab10ad9b4c329705b7bc84</Hash>
</Codenesium>*/