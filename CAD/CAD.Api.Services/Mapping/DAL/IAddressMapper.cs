using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALAddressMapper
	{
		Address MapModelToEntity(
			int id,
			ApiAddressServerRequestModel model);

		ApiAddressServerResponseModel MapEntityToModel(
			Address item);

		List<ApiAddressServerResponseModel> MapEntityToModel(
			List<Address> items);
	}
}

/*<Codenesium>
    <Hash>a470b56cb6a4d09509f19ffc045d28e6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/