using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALCustomerMapper
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
    <Hash>3b7dca04d8f2d36bb8211d85995358c2</Hash>
</Codenesium>*/