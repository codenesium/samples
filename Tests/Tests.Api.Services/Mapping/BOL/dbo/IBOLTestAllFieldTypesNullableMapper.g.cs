using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLTestAllFieldTypesNullableMapper
	{
		BOTestAllFieldTypesNullable MapModelToBO(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel model);

		ApiTestAllFieldTypesNullableServerResponseModel MapBOToModel(
			BOTestAllFieldTypesNullable boTestAllFieldTypesNullable);

		List<ApiTestAllFieldTypesNullableServerResponseModel> MapBOToModel(
			List<BOTestAllFieldTypesNullable> items);
	}
}

/*<Codenesium>
    <Hash>0c8d4115c4fc1655246a4cafdf743e0d</Hash>
</Codenesium>*/