using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALCustomerMapper
	{
		Customer MapBOToEF(
			BOCustomer bo);

		BOCustomer MapEFToBO(
			Customer efCustomer);

		List<BOCustomer> MapEFToBO(
			List<Customer> records);
	}
}

/*<Codenesium>
    <Hash>db71b703946e5819b93f3b4e8a7c5838</Hash>
</Codenesium>*/