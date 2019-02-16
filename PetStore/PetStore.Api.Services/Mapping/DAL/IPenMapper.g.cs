using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALPenMapper
	{
		Pen MapModelToEntity(
			int id,
			ApiPenServerRequestModel model);

		ApiPenServerResponseModel MapEntityToModel(
			Pen item);

		List<ApiPenServerResponseModel> MapEntityToModel(
			List<Pen> items);
	}
}

/*<Codenesium>
    <Hash>8e57fceaa39042955a8397f711398db7</Hash>
</Codenesium>*/