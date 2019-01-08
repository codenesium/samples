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
			ApiTestAllFieldTypeServerRequestModel model);

		ApiTestAllFieldTypeServerResponseModel MapBOToModel(
			BOTestAllFieldType boTestAllFieldType);

		List<ApiTestAllFieldTypeServerResponseModel> MapBOToModel(
			List<BOTestAllFieldType> items);
	}
}

/*<Codenesium>
    <Hash>9a5cc6e096954c2b9d8d4cf9f978b3e6</Hash>
</Codenesium>*/