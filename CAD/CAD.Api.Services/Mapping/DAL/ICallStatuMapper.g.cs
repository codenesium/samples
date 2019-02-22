using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallStatuMapper
	{
		CallStatu MapModelToEntity(
			int id,
			ApiCallStatuServerRequestModel model);

		ApiCallStatuServerResponseModel MapEntityToModel(
			CallStatu item);

		List<ApiCallStatuServerResponseModel> MapEntityToModel(
			List<CallStatu> items);
	}
}

/*<Codenesium>
    <Hash>6571c36c1e2bd9dfec4aa13a803d06a5</Hash>
</Codenesium>*/