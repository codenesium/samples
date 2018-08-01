using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductVendorModelMapper
	{
		public virtual ApiProductVendorResponseModel MapRequestToResponse(
			int productID,
			ApiProductVendorRequestModel request)
		{
			var response = new ApiProductVendorResponseModel();
			response.SetProperties(productID,
			                       request.AverageLeadTime,
			                       request.BusinessEntityID,
			                       request.LastReceiptCost,
			                       request.LastReceiptDate,
			                       request.MaxOrderQty,
			                       request.MinOrderQty,
			                       request.ModifiedDate,
			                       request.OnOrderQty,
			                       request.StandardPrice,
			                       request.UnitMeasureCode);
			return response;
		}

		public virtual ApiProductVendorRequestModel MapResponseToRequest(
			ApiProductVendorResponseModel response)
		{
			var request = new ApiProductVendorRequestModel();
			request.SetProperties(
				response.AverageLeadTime,
				response.BusinessEntityID,
				response.LastReceiptCost,
				response.LastReceiptDate,
				response.MaxOrderQty,
				response.MinOrderQty,
				response.ModifiedDate,
				response.OnOrderQty,
				response.StandardPrice,
				response.UnitMeasureCode);
			return request;
		}

		public JsonPatchDocument<ApiProductVendorRequestModel> CreatePatch(ApiProductVendorRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductVendorRequestModel>();
			patch.Replace(x => x.AverageLeadTime, model.AverageLeadTime);
			patch.Replace(x => x.BusinessEntityID, model.BusinessEntityID);
			patch.Replace(x => x.LastReceiptCost, model.LastReceiptCost);
			patch.Replace(x => x.LastReceiptDate, model.LastReceiptDate);
			patch.Replace(x => x.MaxOrderQty, model.MaxOrderQty);
			patch.Replace(x => x.MinOrderQty, model.MinOrderQty);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.OnOrderQty, model.OnOrderQty);
			patch.Replace(x => x.StandardPrice, model.StandardPrice);
			patch.Replace(x => x.UnitMeasureCode, model.UnitMeasureCode);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>06478a85b25d754c32d20197aa95c4b9</Hash>
</Codenesium>*/