using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBillOfMaterialMapper
	{
		BillOfMaterial MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel model);

		ApiBillOfMaterialServerResponseModel MapBOToModel(
			BillOfMaterial item);

		List<ApiBillOfMaterialServerResponseModel> MapBOToModel(
			List<BillOfMaterial> items);
	}
}

/*<Codenesium>
    <Hash>05363040e0204247d195edf02244c750</Hash>
</Codenesium>*/