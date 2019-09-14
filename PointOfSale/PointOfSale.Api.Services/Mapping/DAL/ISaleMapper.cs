using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
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
    <Hash>9f6ca98d312c55cfb0e3341818ce19eb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/