using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALUnitMeasureMapper
	{
		UnitMeasure MapModelToEntity(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel model);

		ApiUnitMeasureServerResponseModel MapEntityToModel(
			UnitMeasure item);

		List<ApiUnitMeasureServerResponseModel> MapEntityToModel(
			List<UnitMeasure> items);
	}
}

/*<Codenesium>
    <Hash>fa2f097cb28dd9c7146b087cec110b74</Hash>
</Codenesium>*/