using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLCustomerMapper
	{
		BOCustomer MapModelToBO(
			int id,
			ApiCustomerRequestModel model);

		ApiCustomerResponseModel MapBOToModel(
			BOCustomer boCustomer);

		List<ApiCustomerResponseModel> MapBOToModel(
			List<BOCustomer> items);
	}
}

/*<Codenesium>
    <Hash>80cf679dc6de22ceb8278b829913d446</Hash>
</Codenesium>*/