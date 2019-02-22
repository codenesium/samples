using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleRefCapabilityModelMapper
	{
		ApiVehicleRefCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleRefCapabilityClientRequestModel request);

		ApiVehicleRefCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehicleRefCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d6beb9d264e11a915ca8889d12b7445a</Hash>
</Codenesium>*/