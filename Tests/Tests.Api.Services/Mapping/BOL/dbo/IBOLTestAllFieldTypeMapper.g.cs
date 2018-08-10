using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLTestAllFieldTypeMapper
	{
		BOTestAllFieldType MapModelToBO(
			int id,
			ApiTestAllFieldTypeRequestModel model);

		ApiTestAllFieldTypeResponseModel MapBOToModel(
			BOTestAllFieldType boTestAllFieldType);

		List<ApiTestAllFieldTypeResponseModel> MapBOToModel(
			List<BOTestAllFieldType> items);
	}
}

/*<Codenesium>
    <Hash>3658fb243d2a1436876ce382a525eda2</Hash>
</Codenesium>*/