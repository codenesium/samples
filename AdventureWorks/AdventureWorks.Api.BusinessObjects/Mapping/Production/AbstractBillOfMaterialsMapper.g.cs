using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLBillOfMaterialsMapper
	{
		public virtual DTOBillOfMaterials MapModelToDTO(
			int billOfMaterialsID,
			ApiBillOfMaterialsRequestModel model
			)
		{
			DTOBillOfMaterials dtoBillOfMaterials = new DTOBillOfMaterials();

			dtoBillOfMaterials.SetProperties(
				billOfMaterialsID,
				model.BOMLevel,
				model.ComponentID,
				model.EndDate,
				model.ModifiedDate,
				model.PerAssemblyQty,
				model.ProductAssemblyID,
				model.StartDate,
				model.UnitMeasureCode);
			return dtoBillOfMaterials;
		}

		public virtual ApiBillOfMaterialsResponseModel MapDTOToModel(
			DTOBillOfMaterials dtoBillOfMaterials)
		{
			if (dtoBillOfMaterials == null)
			{
				return null;
			}

			var model = new ApiBillOfMaterialsResponseModel();

			model.SetProperties(dtoBillOfMaterials.BillOfMaterialsID, dtoBillOfMaterials.BOMLevel, dtoBillOfMaterials.ComponentID, dtoBillOfMaterials.EndDate, dtoBillOfMaterials.ModifiedDate, dtoBillOfMaterials.PerAssemblyQty, dtoBillOfMaterials.ProductAssemblyID, dtoBillOfMaterials.StartDate, dtoBillOfMaterials.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiBillOfMaterialsResponseModel> MapDTOToModel(
			List<DTOBillOfMaterials> dtos)
		{
			List<ApiBillOfMaterialsResponseModel> response = new List<ApiBillOfMaterialsResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5ba8c87fb6599997dca5b65d8e08462b</Hash>
</Codenesium>*/