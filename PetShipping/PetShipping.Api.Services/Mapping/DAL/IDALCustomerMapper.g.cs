using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>c16b4ad76d781f7bef218363c2c05068</Hash>
</Codenesium>*/