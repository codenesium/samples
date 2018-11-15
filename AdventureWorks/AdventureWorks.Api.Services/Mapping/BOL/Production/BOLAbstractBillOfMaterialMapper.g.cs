using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBillOfMaterialMapper
	{
		public virtual BOBillOfMaterial MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel model
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

		public virtual ApiBillOfMaterialServerResponseModel MapBOToModel(
			BOBillOfMaterial boBillOfMaterial)
		{
			var model = new ApiBillOfMaterialServerResponseModel();

			model.SetProperties(boBillOfMaterial.BillOfMaterialsID, boBillOfMaterial.BOMLevel, boBillOfMaterial.ComponentID, boBillOfMaterial.EndDate, boBillOfMaterial.ModifiedDate, boBillOfMaterial.PerAssemblyQty, boBillOfMaterial.ProductAssemblyID, boBillOfMaterial.StartDate, boBillOfMaterial.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiBillOfMaterialServerResponseModel> MapBOToModel(
			List<BOBillOfMaterial> items)
		{
			List<ApiBillOfMaterialServerResponseModel> response = new List<ApiBillOfMaterialServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>58829233ac3fdaa46a4ecdf001b37bab</Hash>
</Codenesium>*/