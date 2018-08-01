using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLBillOfMaterialMapper
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
    <Hash>13789d5c58df8191f26fbb46344ffc63</Hash>
</Codenesium>*/