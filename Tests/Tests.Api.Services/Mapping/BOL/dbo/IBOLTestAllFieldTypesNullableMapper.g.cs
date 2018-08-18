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
			ApiTestAllFieldTypesNullableRequestModel model);

		ApiTestAllFieldTypesNullableResponseModel MapBOToModel(
			BOTestAllFieldTypesNullable boTestAllFieldTypesNullable);

		List<ApiTestAllFieldTypesNullableResponseModel> MapBOToModel(
			List<BOTestAllFieldTypesNullable> items);
	}
}

/*<Codenesium>
    <Hash>b895fca516f278ac60d6435ffaf4e2ac</Hash>
</Codenesium>*/