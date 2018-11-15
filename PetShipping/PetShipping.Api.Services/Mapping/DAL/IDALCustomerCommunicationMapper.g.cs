using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALCustomerCommunicationMapper
	{
		CustomerCommunication MapBOToEF(
			BOCustomerCommunication bo);

		BOCustomerCommunication MapEFToBO(
			CustomerCommunication efCustomerCommunication);

		List<BOCustomerCommunication> MapEFToBO(
			List<CustomerCommunication> records);
	}
}

/*<Codenesium>
    <Hash>b168f4c4b41d78dff0dd4f74a6a216a0</Hash>
</Codenesium>*/