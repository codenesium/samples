using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALBillOfMaterialsMapper
	{
		public virtual void MapDTOToEF(
			int billOfMaterialsID,
			DTOBillOfMaterials dto,
			BillOfMaterials efBillOfMaterials)
		{
			efBillOfMaterials.SetProperties(
				billOfMaterialsID,
				dto.BOMLevel,
				dto.ComponentID,
				dto.EndDate,
				dto.ModifiedDate,
				dto.PerAssemblyQty,
				dto.ProductAssemblyID,
				dto.StartDate,
				dto.UnitMeasureCode);
		}

		public virtual DTOBillOfMaterials MapEFToDTO(
			BillOfMaterials ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOBillOfMaterials();

			dto.SetProperties(
				ef.BillOfMaterialsID,
				ef.BOMLevel,
				ef.ComponentID,
				ef.EndDate,
				ef.ModifiedDate,
				ef.PerAssemblyQty,
				ef.ProductAssemblyID,
				ef.StartDate,
				ef.UnitMeasureCode);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>4a5fc21c32e69ddaf3939c21671cd6a6</Hash>
</Codenesium>*/