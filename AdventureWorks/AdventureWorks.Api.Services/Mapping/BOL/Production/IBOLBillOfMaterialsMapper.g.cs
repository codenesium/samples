using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLBillOfMaterialsMapper
	{
		BOBillOfMaterials MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialsRequestModel model);

		ApiBillOfMaterialsResponseModel MapBOToModel(
			BOBillOfMaterials boBillOfMaterials);

		List<ApiBillOfMaterialsResponseModel> MapBOToModel(
			List<BOBillOfMaterials> bos);
	}
}

/*<Codenesium>
    <Hash>4e740b169172317e431ed5946b344a5b</Hash>
</Codenesium>*/