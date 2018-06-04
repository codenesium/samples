using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductVendorMapper
	{
		public virtual BOProductVendor MapModelToBO(
			int productID,
			ApiProductVendorRequestModel model
			)
		{
			BOProductVendor BOProductVendor = new BOProductVendor();

			BOProductVendor.SetProperties(
				productID,
				model.AverageLeadTime,
				model.BusinessEntityID,
				model.LastReceiptCost,
				model.LastReceiptDate,
				model.MaxOrderQty,
				model.MinOrderQty,
				model.ModifiedDate,
				model.OnOrderQty,
				model.StandardPrice,
				model.UnitMeasureCode);
			return BOProductVendor;
		}

		public virtual ApiProductVendorResponseModel MapBOToModel(
			BOProductVendor BOProductVendor)
		{
			if (BOProductVendor == null)
			{
				return null;
			}

			var model = new ApiProductVendorResponseModel();

			model.SetProperties(BOProductVendor.AverageLeadTime, BOProductVendor.BusinessEntityID, BOProductVendor.LastReceiptCost, BOProductVendor.LastReceiptDate, BOProductVendor.MaxOrderQty, BOProductVendor.MinOrderQty, BOProductVendor.ModifiedDate, BOProductVendor.OnOrderQty, BOProductVendor.ProductID, BOProductVendor.StandardPrice, BOProductVendor.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiProductVendorResponseModel> MapBOToModel(
			List<BOProductVendor> BOs)
		{
			List<ApiProductVendorResponseModel> response = new List<ApiProductVendorResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>496a6681075f8e183bf433b077df3b71</Hash>
</Codenesium>*/