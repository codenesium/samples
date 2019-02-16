using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALUnitMeasureMapper
	{
		UnitMeasure MapModelToBO(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel model);

		ApiUnitMeasureServerResponseModel MapBOToModel(
			UnitMeasure item);

		List<ApiUnitMeasureServerResponseModel> MapBOToModel(
			List<UnitMeasure> items);
	}
}

/*<Codenesium>
    <Hash>c5cb852be2545a5402f26c2a40afd808</Hash>
</Codenesium>*/