using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>b16681a7a7099c38061f594e7b95174f</Hash>
</Codenesium>*/