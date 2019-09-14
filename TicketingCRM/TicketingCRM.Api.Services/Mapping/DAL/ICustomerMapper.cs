using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALCustomerMapper
	{
		Customer MapModelToEntity(
			int id,
			ApiCustomerServerRequestModel model);

		ApiCustomerServerResponseModel MapEntityToModel(
			Customer item);

		List<ApiCustomerServerResponseModel> MapEntityToModel(
			List<Customer> items);
	}
}

/*<Codenesium>
    <Hash>776b27b1ee52a438bb43e00a01a2c17f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/