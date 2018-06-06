using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLUnitMeasureMapper
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
    <Hash>0f080c3e59f66210e40e0257b2afa642</Hash>
</Codenesium>*/