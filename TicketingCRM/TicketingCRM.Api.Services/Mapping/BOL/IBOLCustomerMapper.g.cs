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
    <Hash>201b3cbd75eca1ead2ef4170048eabf7</Hash>
</Codenesium>*/