using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALUnitDispositionMapper
	{
		UnitDisposition MapModelToEntity(
			int id,
			ApiUnitDispositionServerRequestModel model);

		ApiUnitDispositionServerResponseModel MapEntityToModel(
			UnitDisposition item);

		List<ApiUnitDispositionServerResponseModel> MapEntityToModel(
			List<UnitDisposition> items);
	}
}

/*<Codenesium>
    <Hash>ce1855d229eeb72c4b590faa67d114c2</Hash>
</Codenesium>*/