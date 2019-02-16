using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCultureMapper
	{
		Culture MapModelToBO(
			string cultureID,
			ApiCultureServerRequestModel model);

		ApiCultureServerResponseModel MapBOToModel(
			Culture item);

		List<ApiCultureServerResponseModel> MapBOToModel(
			List<Culture> items);
	}
}

/*<Codenesium>
    <Hash>65472a65af522494122f7c59b7927983</Hash>
</Codenesium>*/