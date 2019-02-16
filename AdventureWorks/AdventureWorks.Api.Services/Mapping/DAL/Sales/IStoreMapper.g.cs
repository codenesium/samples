using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALStoreMapper
	{
		Store MapModelToBO(
			int businessEntityID,
			ApiStoreServerRequestModel model);

		ApiStoreServerResponseModel MapBOToModel(
			Store item);

		List<ApiStoreServerResponseModel> MapBOToModel(
			List<Store> items);
	}
}

/*<Codenesium>
    <Hash>84db7b98cc2d460e18f994e9e9b9481f</Hash>
</Codenesium>*/