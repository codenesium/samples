using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALEmployeeMapper
	{
		Employee MapModelToEntity(
			int id,
			ApiEmployeeServerRequestModel model);

		ApiEmployeeServerResponseModel MapEntityToModel(
			Employee item);

		List<ApiEmployeeServerResponseModel> MapEntityToModel(
			List<Employee> items);
	}
}

/*<Codenesium>
    <Hash>e77646771e562df464b4e44da84725ae</Hash>
</Codenesium>*/