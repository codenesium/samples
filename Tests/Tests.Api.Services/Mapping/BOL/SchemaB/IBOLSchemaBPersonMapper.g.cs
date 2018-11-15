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
			ApiSchemaBPersonServerRequestModel model);

		ApiSchemaBPersonServerResponseModel MapBOToModel(
			BOSchemaBPerson boSchemaBPerson);

		List<ApiSchemaBPersonServerResponseModel> MapBOToModel(
			List<BOSchemaBPerson> items);
	}
}

/*<Codenesium>
    <Hash>2f5b077dd56a900b26519e8195e2517f</Hash>
</Codenesium>*/