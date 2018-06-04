using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBillOfMaterialsMapper
	{
		public virtual BOBillOfMaterials MapModelToBO(
			int billOfMaterialsID,
			ApiBillOfMaterialsRequestModel model
			)
		{
			BOBillOfMaterials BOBillOfMaterials = new BOBillOfMaterials();

			BOBillOfMaterials.SetProperties(
				billOfMaterialsID,
				model.BOMLevel,
				model.ComponentID,
				model.EndDate,
				model.ModifiedDate,
				model.PerAssemblyQty,
				model.ProductAssemblyID,
				model.StartDate,
				model.UnitMeasureCode);
			return BOBillOfMaterials;
		}

		public virtual ApiBillOfMaterialsResponseModel MapBOToModel(
			BOBillOfMaterials BOBillOfMaterials)
		{
			if (BOBillOfMaterials == null)
			{
				return null;
			}

			var model = new ApiBillOfMaterialsResponseModel();

			model.SetProperties(BOBillOfMaterials.BillOfMaterialsID, BOBillOfMaterials.BOMLevel, BOBillOfMaterials.ComponentID, BOBillOfMaterials.EndDate, BOBillOfMaterials.ModifiedDate, BOBillOfMaterials.PerAssemblyQty, BOBillOfMaterials.ProductAssemblyID, BOBillOfMaterials.StartDate, BOBillOfMaterials.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiBillOfMaterialsResponseModel> MapBOToModel(
			List<BOBillOfMaterials> BOs)
		{
			List<ApiBillOfMaterialsResponseModel> response = new List<ApiBillOfMaterialsResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>20d9bd9ae346263c58fa385d85bf820b</Hash>
</Codenesium>*/