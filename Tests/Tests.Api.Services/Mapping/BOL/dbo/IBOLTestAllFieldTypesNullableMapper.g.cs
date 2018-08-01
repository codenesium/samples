using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLTestAllFieldTypesNullableMapper
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
    <Hash>504e80cd34978b3139ebc0587fc993ed</Hash>
</Codenesium>*/