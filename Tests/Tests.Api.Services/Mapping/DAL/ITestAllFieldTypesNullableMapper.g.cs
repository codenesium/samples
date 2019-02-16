using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTestAllFieldTypesNullableMapper
	{
		TestAllFieldTypesNullable MapModelToEntity(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel model);

		ApiTestAllFieldTypesNullableServerResponseModel MapEntityToModel(
			TestAllFieldTypesNullable item);

		List<ApiTestAllFieldTypesNullableServerResponseModel> MapEntityToModel(
			List<TestAllFieldTypesNullable> items);
	}
}

/*<Codenesium>
    <Hash>b735ded3840ff35dafb2ef0ae62c2958</Hash>
</Codenesium>*/