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
			List<BOBillOfMaterials> items);
	}
}

/*<Codenesium>
    <Hash>137bfd8ad604e34ad7cec69c21175337</Hash>
</Codenesium>*/