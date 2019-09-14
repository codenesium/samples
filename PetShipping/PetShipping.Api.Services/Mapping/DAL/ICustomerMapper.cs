using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>ebddfdb8d357f99962c0df118d7206d3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/