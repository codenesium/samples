using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBillOfMaterialMapper
	{
		BillOfMaterial MapModelToEntity(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel model);

		ApiBillOfMaterialServerResponseModel MapEntityToModel(
			BillOfMaterial item);

		List<ApiBillOfMaterialServerResponseModel> MapEntityToModel(
			List<BillOfMaterial> items);
	}
}

/*<Codenesium>
    <Hash>03c9beff42fbdbc978819e95ca81dd58</Hash>
</Codenesium>*/