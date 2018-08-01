using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLTestAllFieldTypeMapper
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
    <Hash>3fb4c803333f85dd0d987e5b74c6b86c</Hash>
</Codenesium>*/