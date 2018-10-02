using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLCompositePrimaryKeyMapper
	{
		BOCompositePrimaryKey MapModelToBO(
			int id,
			ApiCompositePrimaryKeyRequestModel model);

		ApiCompositePrimaryKeyResponseModel MapBOToModel(
			BOCompositePrimaryKey boCompositePrimaryKey);

		List<ApiCompositePrimaryKeyResponseModel> MapBOToModel(
			List<BOCompositePrimaryKey> items);
	}
}

/*<Codenesium>
    <Hash>d09154170e9b94589fe9a22399e985e4</Hash>
</Codenesium>*/