using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPasswordMapper
	{
		Password MapModelToBO(
			int businessEntityID,
			ApiPasswordServerRequestModel model);

		ApiPasswordServerResponseModel MapBOToModel(
			Password item);

		List<ApiPasswordServerResponseModel> MapBOToModel(
			List<Password> items);
	}
}

/*<Codenesium>
    <Hash>a9400f721cf29e9578fc4c5ee9b16d42</Hash>
</Codenesium>*/