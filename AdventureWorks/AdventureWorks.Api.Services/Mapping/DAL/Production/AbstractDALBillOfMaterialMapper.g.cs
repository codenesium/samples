using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBillOfMaterialMapper
	{
		public virtual BillOfMaterial MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel model
			)
		{
			BillOfMaterial item = new BillOfMaterial();
			item.SetProperties(
				billOfMaterialsID,
				model.BOMLevel,
				model.ComponentID,
				model.EndDate,
				model.ModifiedDate,
				model.PerAssemblyQty,
				model.ProductAssemblyID,
				model.StartDate,
				model.UnitMeasureCode);
			return item;
		}

		public virtual ApiBillOfMaterialServerResponseModel MapBOToModel(
			BillOfMaterial item)
		{
			var model = new ApiBillOfMaterialServerResponseModel();

			model.SetProperties(item.BillOfMaterialsID, item.BOMLevel, item.ComponentID, item.EndDate, item.ModifiedDate, item.PerAssemblyQty, item.ProductAssemblyID, item.StartDate, item.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiBillOfMaterialServerResponseModel> MapBOToModel(
			List<BillOfMaterial> items)
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
    <Hash>bcfe7bdf5093e6f02b6687cc80bbd09a</Hash>
</Codenesium>*/