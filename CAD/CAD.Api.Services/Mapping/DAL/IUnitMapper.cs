using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALUnitMapper
	{
		Unit MapModelToEntity(
			int id,
			ApiUnitServerRequestModel model);

		ApiUnitServerResponseModel MapEntityToModel(
			Unit item);

		List<ApiUnitServerResponseModel> MapEntityToModel(
			List<Unit> items);
	}
}

/*<Codenesium>
    <Hash>05c10e77dcd435c96255e8e39547ff01</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/