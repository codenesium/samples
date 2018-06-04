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
			List<BOUnitMeasure> bos);
	}
}

/*<Codenesium>
    <Hash>b17393597b15994b065fd437047f1e46</Hash>
</Codenesium>*/