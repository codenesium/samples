using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLUnitMeasureMapper
	{
		BOUnitMeasure MapModelToBO(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model);

		ApiUnitMeasureResponseModel MapBOToModel(
			BOUnitMeasure boUnitMeasure);

		List<ApiUnitMeasureResponseModel> MapBOToModel(
			List<BOUnitMeasure> items);
	}
}

/*<Codenesium>
    <Hash>805533dbf3c2036261576ea31a50d7e9</Hash>
</Codenesium>*/