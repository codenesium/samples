using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLSchemaBPersonMapper
	{
		BOSchemaBPerson MapModelToBO(
			int id,
			ApiSchemaBPersonRequestModel model);

		ApiSchemaBPersonResponseModel MapBOToModel(
			BOSchemaBPerson boSchemaBPerson);

		List<ApiSchemaBPersonResponseModel> MapBOToModel(
			List<BOSchemaBPerson> items);
	}
}

/*<Codenesium>
    <Hash>67f24af3a6739fec6b78ab1129f044e9</Hash>
</Codenesium>*/