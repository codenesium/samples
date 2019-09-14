using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallStatusMapper
	{
		CallStatus MapModelToEntity(
			int id,
			ApiCallStatusServerRequestModel model);

		ApiCallStatusServerResponseModel MapEntityToModel(
			CallStatus item);

		List<ApiCallStatusServerResponseModel> MapEntityToModel(
			List<CallStatus> items);
	}
}

/*<Codenesium>
    <Hash>db9e452fa8641ff0e0f9255ea5f93288</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/