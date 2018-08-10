using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
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
    <Hash>d6b63d019712259630be15aec20b69a9</Hash>
</Codenesium>*/