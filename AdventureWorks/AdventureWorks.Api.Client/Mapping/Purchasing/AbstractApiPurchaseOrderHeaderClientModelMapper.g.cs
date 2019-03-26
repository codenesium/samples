using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiPurchaseOrderHeaderModelMapper
	{
		public virtual ApiPurchaseOrderHeaderClientResponseModel MapClientRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderClientRequestModel request)
		{
			var response = new ApiPurchaseOrderHeaderClientResponseModel();
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

		public virtual ApiPurchaseOrderHeaderClientRequestModel MapClientResponseToRequest(
			ApiPurchaseOrderHeaderClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>67ed51d1b5fcdc7a09b7573d13bd9ec9</Hash>
</Codenesium>*/