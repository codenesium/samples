using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALSaleMapper
	{
		Sale MapModelToEntity(
			int id,
			ApiSaleServerRequestModel model);

		ApiSaleServerResponseModel MapEntityToModel(
			Sale item);

		List<ApiSaleServerResponseModel> MapEntityToModel(
			List<Sale> items);
	}
}

/*<Codenesium>
    <Hash>9f1d45ffab2d1fc179f5ee34d1160dfd</Hash>
</Codenesium>*/