using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IDALProductMapper
	{
		Product MapModelToEntity(
			int id,
			ApiProductServerRequestModel model);

		ApiProductServerResponseModel MapEntityToModel(
			Product item);

		List<ApiProductServerResponseModel> MapEntityToModel(
			List<Product> items);
	}
}

/*<Codenesium>
    <Hash>bd8bf593ec3f5e6cefa7baa8fc9bb39a</Hash>
</Codenesium>*/