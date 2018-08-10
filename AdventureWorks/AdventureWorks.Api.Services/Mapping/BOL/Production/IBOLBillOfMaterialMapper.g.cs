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
    <Hash>9cea87b938732c78aa3b47e5957e1f77</Hash>
</Codenesium>*/