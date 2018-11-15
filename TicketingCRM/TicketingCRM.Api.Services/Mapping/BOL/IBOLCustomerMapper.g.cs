using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLCustomerMapper
	{
		BOCustomer MapModelToBO(
			int id,
			ApiCustomerServerRequestModel model);

		ApiCustomerServerResponseModel MapBOToModel(
			BOCustomer boCustomer);

		List<ApiCustomerServerResponseModel> MapBOToModel(
			List<BOCustomer> items);
	}
}

/*<Codenesium>
    <Hash>646397b7d84a29bc88ca8bd5924e62de</Hash>
</Codenesium>*/