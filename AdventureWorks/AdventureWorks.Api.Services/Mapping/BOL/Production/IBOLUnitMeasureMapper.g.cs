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
    <Hash>1b85d5b18fa22330c33d994c3e50c5aa</Hash>
</Codenesium>*/