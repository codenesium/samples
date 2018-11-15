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
			ApiBillOfMaterialServerRequestModel model);

		ApiBillOfMaterialServerResponseModel MapBOToModel(
			BOBillOfMaterial boBillOfMaterial);

		List<ApiBillOfMaterialServerResponseModel> MapBOToModel(
			List<BOBillOfMaterial> items);
	}
}

/*<Codenesium>
    <Hash>9ac0289c047487e2024219ba7333dce5</Hash>
</Codenesium>*/