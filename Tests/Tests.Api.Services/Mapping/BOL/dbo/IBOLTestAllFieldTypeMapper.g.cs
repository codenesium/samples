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
    <Hash>76d54b37aa77c925ccb1f2bfe07218a4</Hash>
</Codenesium>*/