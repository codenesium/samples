using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesOrderHeaderServerModelMapper
	{
		public virtual ApiSalesOrderHeaderServerResponseModel MapServerRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel request)
		{
			var response = new ApiSalesOrderHeaderServerResponseModel();
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

		public virtual ApiSalesOrderHeaderServerRequestModel MapServerResponseToRequest(
			ApiSalesOrderHeaderServerResponseModel response)
		{
			var request = new ApiSalesOrderHeaderServerRequestModel();
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

		public virtual ApiSalesOrderHeaderClientRequestModel MapServerResponseToClientRequest(
			ApiSalesOrderHeaderServerResponseModel response)
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

		public JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel> CreatePatch(ApiSalesOrderHeaderServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel>();
			patch.Replace(x => x.AccountNumber, model.AccountNumber);
			patch.Replace(x => x.BillToAddressID, model.BillToAddressID);
			patch.Replace(x => x.Comment, model.Comment);
			patch.Replace(x => x.CreditCardApprovalCode, model.CreditCardApprovalCode);
			patch.Replace(x => x.CreditCardID, model.CreditCardID);
			patch.Replace(x => x.CurrencyRateID, model.CurrencyRateID);
			patch.Replace(x => x.CustomerID, model.CustomerID);
			patch.Replace(x => x.DueDate, model.DueDate);
			patch.Replace(x => x.Freight, model.Freight);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.OnlineOrderFlag, model.OnlineOrderFlag);
			patch.Replace(x => x.OrderDate, model.OrderDate);
			patch.Replace(x => x.PurchaseOrderNumber, model.PurchaseOrderNumber);
			patch.Replace(x => x.RevisionNumber, model.RevisionNumber);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesOrderNumber, model.SalesOrderNumber);
			patch.Replace(x => x.SalesPersonID, model.SalesPersonID);
			patch.Replace(x => x.ShipDate, model.ShipDate);
			patch.Replace(x => x.ShipMethodID, model.ShipMethodID);
			patch.Replace(x => x.ShipToAddressID, model.ShipToAddressID);
			patch.Replace(x => x.Status, model.Status);
			patch.Replace(x => x.SubTotal, model.SubTotal);
			patch.Replace(x => x.TaxAmt, model.TaxAmt);
			patch.Replace(x => x.TerritoryID, model.TerritoryID);
			patch.Replace(x => x.TotalDue, model.TotalDue);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>116520fa5f7c488056c33f42fd91cdf6</Hash>
</Codenesium>*/