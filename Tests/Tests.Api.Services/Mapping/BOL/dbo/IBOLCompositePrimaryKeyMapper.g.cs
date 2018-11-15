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
			ApiCompositePrimaryKeyServerRequestModel model);

		ApiCompositePrimaryKeyServerResponseModel MapBOToModel(
			BOCompositePrimaryKey boCompositePrimaryKey);

		List<ApiCompositePrimaryKeyServerResponseModel> MapBOToModel(
			List<BOCompositePrimaryKey> items);
	}
}

/*<Codenesium>
    <Hash>338535b175aef8b7de0a37436906740a</Hash>
</Codenesium>*/