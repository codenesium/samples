using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleOfficerModelMapper
	{
		ApiVehicleOfficerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleOfficerClientRequestModel request);

		ApiVehicleOfficerClientRequestModel MapClientResponseToRequest(
			ApiVehicleOfficerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>50845d468a3bee530b0e9e9b7c9be103</Hash>
</Codenesium>*/