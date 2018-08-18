using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiSalesOrderDetailModelMapper
	{
		public virtual ApiSalesOrderDetailResponseModel MapRequestToResponse(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel request)
		{
			var response = new ApiSalesOrderDetailResponseModel();
			response.SetProperties(salesOrderID,
			                       request.CarrierTrackingNumber,
			                       request.LineTotal,
			                       request.ModifiedDate,
			                       request.OrderQty,
			                       request.ProductID,
			                       request.Rowguid,
			                       request.SalesOrderDetailID,
			                       request.SpecialOfferID,
			                       request.UnitPrice,
			                       request.UnitPriceDiscount);
			return response;
		}

		public virtual ApiSalesOrderDetailRequestModel MapResponseToRequest(
			ApiSalesOrderDetailResponseModel response)
		{
			var request = new ApiSalesOrderDetailRequestModel();
			request.SetProperties(
				response.CarrierTrackingNumber,
				response.LineTotal,
				response.ModifiedDate,
				response.OrderQty,
				response.ProductID,
				response.Rowguid,
				response.SalesOrderDetailID,
				response.SpecialOfferID,
				response.UnitPrice,
				response.UnitPriceDiscount);
			return request;
		}

		public JsonPatchDocument<ApiSalesOrderDetailRequestModel> CreatePatch(ApiSalesOrderDetailRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesOrderDetailRequestModel>();
			patch.Replace(x => x.CarrierTrackingNumber, model.CarrierTrackingNumber);
			patch.Replace(x => x.LineTotal, model.LineTotal);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.OrderQty, model.OrderQty);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesOrderDetailID, model.SalesOrderDetailID);
			patch.Replace(x => x.SpecialOfferID, model.SpecialOfferID);
			patch.Replace(x => x.UnitPrice, model.UnitPrice);
			patch.Replace(x => x.UnitPriceDiscount, model.UnitPriceDiscount);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>99f6301722756560ff23bcb6b9c4329d</Hash>
</Codenesium>*/