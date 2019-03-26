using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiPurchaseOrderHeaderServerModelMapper
	{
		public virtual ApiPurchaseOrderHeaderServerResponseModel MapServerRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel request)
		{
			var response = new ApiPurchaseOrderHeaderServerResponseModel();
			response.SetProperties(purchaseOrderID,
			                       request.EmployeeID,
			                       request.Freight,
			                       request.ModifiedDate,
			                       request.OrderDate,
			                       request.RevisionNumber,
			                       request.ShipDate,
			                       request.ShipMethodID,
			                       request.Status,
			                       request.SubTotal,
			                       request.TaxAmt,
			                       request.TotalDue,
			                       request.VendorID);
			return response;
		}

		public virtual ApiPurchaseOrderHeaderServerRequestModel MapServerResponseToRequest(
			ApiPurchaseOrderHeaderServerResponseModel response)
		{
			var request = new ApiPurchaseOrderHeaderServerRequestModel();
			request.SetProperties(
				response.EmployeeID,
				response.Freight,
				response.ModifiedDate,
				response.OrderDate,
				response.RevisionNumber,
				response.ShipDate,
				response.ShipMethodID,
				response.Status,
				response.SubTotal,
				response.TaxAmt,
				response.TotalDue,
				response.VendorID);
			return request;
		}

		public virtual ApiPurchaseOrderHeaderClientRequestModel MapServerResponseToClientRequest(
			ApiPurchaseOrderHeaderServerResponseModel response)
		{
			var request = new ApiPurchaseOrderHeaderClientRequestModel();
			request.SetProperties(
				response.EmployeeID,
				response.Freight,
				response.ModifiedDate,
				response.OrderDate,
				response.RevisionNumber,
				response.ShipDate,
				response.ShipMethodID,
				response.Status,
				response.SubTotal,
				response.TaxAmt,
				response.TotalDue,
				response.VendorID);
			return request;
		}

		public JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel> CreatePatch(ApiPurchaseOrderHeaderServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel>();
			patch.Replace(x => x.EmployeeID, model.EmployeeID);
			patch.Replace(x => x.Freight, model.Freight);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.OrderDate, model.OrderDate);
			patch.Replace(x => x.RevisionNumber, model.RevisionNumber);
			patch.Replace(x => x.ShipDate, model.ShipDate);
			patch.Replace(x => x.ShipMethodID, model.ShipMethodID);
			patch.Replace(x => x.Status, model.Status);
			patch.Replace(x => x.SubTotal, model.SubTotal);
			patch.Replace(x => x.TaxAmt, model.TaxAmt);
			patch.Replace(x => x.TotalDue, model.TotalDue);
			patch.Replace(x => x.VendorID, model.VendorID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>be1365a4ad8585b13f2adf2287bd183e</Hash>
</Codenesium>*/