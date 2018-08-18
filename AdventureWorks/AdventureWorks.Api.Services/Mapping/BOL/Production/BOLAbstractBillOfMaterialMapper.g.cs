using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBillOfMaterialMapper
	{
		public virtual BOBillOfMaterial MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialRequestModel model
			)
		{
			BOBillOfMaterial boBillOfMaterial = new BOBillOfMaterial();
			boBillOfMaterial.SetProperties(
				billOfMaterialsID,
				model.BOMLevel,
				model.ComponentID,
				model.EndDate,
				model.ModifiedDate,
				model.PerAssemblyQty,
				model.ProductAssemblyID,
				model.StartDate,
				model.UnitMeasureCode);
			return boBillOfMaterial;
		}

		public virtual ApiBillOfMaterialResponseModel MapBOToModel(
			BOBillOfMaterial boBillOfMaterial)
		{
			var model = new ApiBillOfMaterialResponseModel();

			model.SetProperties(boBillOfMaterial.BillOfMaterialsID, boBillOfMaterial.BOMLevel, boBillOfMaterial.ComponentID, boBillOfMaterial.EndDate, boBillOfMaterial.ModifiedDate, boBillOfMaterial.PerAssemblyQty, boBillOfMaterial.ProductAssemblyID, boBillOfMaterial.StartDate, boBillOfMaterial.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiBillOfMaterialResponseModel> MapBOToModel(
			List<BOBillOfMaterial> items)
		{
			List<ApiBillOfMaterialResponseModel> response = new List<ApiBillOfMaterialResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6c59ddd25742b3e44e2043b554e37af8</Hash>
</Codenesium>*/