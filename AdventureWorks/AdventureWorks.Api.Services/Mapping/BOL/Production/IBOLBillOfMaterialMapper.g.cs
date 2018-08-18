using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLBillOfMaterialMapper
	{
		BOBillOfMaterial MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialRequestModel model);

		ApiBillOfMaterialResponseModel MapBOToModel(
			BOBillOfMaterial boBillOfMaterial);

		List<ApiBillOfMaterialResponseModel> MapBOToModel(
			List<BOBillOfMaterial> items);
	}
}

/*<Codenesium>
    <Hash>e130f6e79550f00b17d5a3561979f73c</Hash>
</Codenesium>*/