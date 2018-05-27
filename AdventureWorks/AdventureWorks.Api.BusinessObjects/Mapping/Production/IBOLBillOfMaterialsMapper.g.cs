using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLBillOfMaterialsMapper
	{
		DTOBillOfMaterials MapModelToDTO(
			int billOfMaterialsID,
			ApiBillOfMaterialsRequestModel model);

		ApiBillOfMaterialsResponseModel MapDTOToModel(
			DTOBillOfMaterials dtoBillOfMaterials);

		List<ApiBillOfMaterialsResponseModel> MapDTOToModel(
			List<DTOBillOfMaterials> dtos);
	}
}

/*<Codenesium>
    <Hash>4d11e32547c44aef3963d0803089363e</Hash>
</Codenesium>*/