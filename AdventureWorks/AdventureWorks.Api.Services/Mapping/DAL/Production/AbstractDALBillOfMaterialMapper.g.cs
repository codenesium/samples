using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALBillOfMaterialMapper
	{
		public virtual BillOfMaterial MapModelToEntity(
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

		public virtual ApiBillOfMaterialServerResponseModel MapEntityToModel(
			BillOfMaterial item)
		{
			var model = new ApiBillOfMaterialServerResponseModel();

			model.SetProperties(item.BillOfMaterialsID,
			                    item.BOMLevel,
			                    item.ComponentID,
			                    item.EndDate,
			                    item.ModifiedDate,
			                    item.PerAssemblyQty,
			                    item.ProductAssemblyID,
			                    item.StartDate,
			                    item.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiBillOfMaterialServerResponseModel> MapEntityToModel(
			List<BillOfMaterial> items)
		{
			List<ApiBillOfMaterialServerResponseModel> response = new List<ApiBillOfMaterialServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a6e17d5ae3033cfe9c71c5c42a5e90a5</Hash>
</Codenesium>*/