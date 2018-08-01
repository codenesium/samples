using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiPurchaseOrderHeaderModelMapper
	{
		public virtual ApiPurchaseOrderHeaderResponseModel MapRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel request)
		{
			var response = new ApiPurchaseOrderHeaderResponseModel();
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

		public virtual ApiPurchaseOrderHeaderRequestModel MapResponseToRequest(
			ApiPurchaseOrderHeaderResponseModel response)
		{
			var request = new ApiPurchaseOrderHeaderRequestModel();
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

		public JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel> CreatePatch(ApiPurchaseOrderHeaderRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel>();
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
    <Hash>830bcc357ba7e192eff1af2315e1ae72</Hash>
</Codenesium>*/