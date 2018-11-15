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
			ApiUnitMeasureServerRequestModel model);

		ApiUnitMeasureServerResponseModel MapBOToModel(
			BOUnitMeasure boUnitMeasure);

		List<ApiUnitMeasureServerResponseModel> MapBOToModel(
			List<BOUnitMeasure> items);
	}
}

/*<Codenesium>
    <Hash>40c7b1443164eeffa7016961b99e9347</Hash>
</Codenesium>*/