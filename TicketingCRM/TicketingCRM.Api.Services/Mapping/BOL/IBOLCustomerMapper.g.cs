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
			ApiCustomerRequestModel model);

		ApiCustomerResponseModel MapBOToModel(
			BOCustomer boCustomer);

		List<ApiCustomerResponseModel> MapBOToModel(
			List<BOCustomer> items);
	}
}

/*<Codenesium>
    <Hash>0aba75338ab80fa9b51d557319270d7e</Hash>
</Codenesium>*/