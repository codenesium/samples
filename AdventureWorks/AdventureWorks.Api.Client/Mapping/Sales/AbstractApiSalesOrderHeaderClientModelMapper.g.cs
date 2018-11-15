using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiSalesOrderHeaderModelMapper
	{
		public virtual ApiSalesOrderHeaderClientResponseModel MapClientRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderClientRequestModel request)
		{
			var response = new ApiSalesOrderHeaderClientResponseModel();
			response.SetProperties(salesOrderID,
			                       request.AccountNumber,
			                       request.BillToAddressID,
			                       request.Comment,
			                       request.CreditCardApprovalCode,
			                       request.CreditCardID,
			                       request.CurrencyRateID,
			                       request.CustomerID,
			                       request.DueDate,
			                       request.Freight,
			                       request.ModifiedDate,
			                       request.OnlineOrderFlag,
			                       request.OrderDate,
			                       request.PurchaseOrderNumber,
			                       request.RevisionNumber,
			                       request.Rowguid,
			                       request.SalesOrderNumber,
			                       request.SalesPersonID,
			                       request.ShipDate,
			                       request.ShipMethodID,
			                       request.ShipToAddressID,
			                       request.Status,
			                       request.SubTotal,
			                       request.TaxAmt,
			                       request.TerritoryID,
			                       request.TotalDue);
			return response;
		}

		public virtual ApiSalesOrderHeaderClientRequestModel MapClientResponseToRequest(
			ApiSalesOrderHeaderClientResponseModel response)
		{
			var request = new ApiSalesOrderHeaderClientRequestModel();
			request.SetProperties(
				response.AccountNumber,
				response.BillToAddressID,
				response.Comment,
				response.CreditCardApprovalCode,
				response.CreditCardID,
				response.CurrencyRateID,
				response.CustomerID,
				response.DueDate,
				response.Freight,
				response.ModifiedDate,
				response.OnlineOrderFlag,
				response.OrderDate,
				response.PurchaseOrderNumber,
				response.RevisionNumber,
				response.Rowguid,
				response.SalesOrderNumber,
				response.SalesPersonID,
				response.ShipDate,
				response.ShipMethodID,
				response.ShipToAddressID,
				response.Status,
				response.SubTotal,
				response.TaxAmt,
				response.TerritoryID,
				response.TotalDue);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>241e001a1779cb0dddabdc51424f3bc3</Hash>
</Codenesium>*/