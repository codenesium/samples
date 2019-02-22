using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallPersonMapper
	{
		CallPerson MapModelToEntity(
			int id,
			ApiCallPersonServerRequestModel model);

		ApiCallPersonServerResponseModel MapEntityToModel(
			CallPerson item);

		List<ApiCallPersonServerResponseModel> MapEntityToModel(
			List<CallPerson> items);
	}
}

/*<Codenesium>
    <Hash>4d5aba008b08dc24eb60a3cd2577e105</Hash>
</Codenesium>*/