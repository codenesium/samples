using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALBillOfMaterialsMapper
	{
		void MapDTOToEF(
			int billOfMaterialsID,
			DTOBillOfMaterials dto,
			BillOfMaterials efBillOfMaterials);

		DTOBillOfMaterials MapEFToDTO(
			BillOfMaterials efBillOfMaterials);
	}
}

/*<Codenesium>
    <Hash>1157dfea4793bc88006ba0691269861a</Hash>
</Codenesium>*/