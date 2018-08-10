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
    <Hash>95578f12e9de3590882470bcca46aa98</Hash>
</Codenesium>*/