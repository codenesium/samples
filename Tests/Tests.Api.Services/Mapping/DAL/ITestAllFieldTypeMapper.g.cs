using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTestAllFieldTypeMapper
	{
		TestAllFieldType MapModelToEntity(
			int id,
			ApiTestAllFieldTypeServerRequestModel model);

		ApiTestAllFieldTypeServerResponseModel MapEntityToModel(
			TestAllFieldType item);

		List<ApiTestAllFieldTypeServerResponseModel> MapEntityToModel(
			List<TestAllFieldType> items);
	}
}

/*<Codenesium>
    <Hash>9cc0af8f853d788031173d655dda8a01</Hash>
</Codenesium>*/