using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
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
    <Hash>69e4b4ebda2497f13e77351cbc504b8b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/