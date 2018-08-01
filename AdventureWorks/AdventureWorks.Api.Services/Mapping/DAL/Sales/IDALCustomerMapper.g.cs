using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
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
    <Hash>d0f3c737200df7acc350becebe19ae9e</Hash>
</Codenesium>*/