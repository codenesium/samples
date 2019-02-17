using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesOrderHeaderMapper
	{
		public virtual SalesOrderHeader MapModelToEntity(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel model
			)
		{
			SalesOrderHeader item = new SalesOrderHeader();
			item.SetProperties(
				salesOrderID,
				model.AccountNumber,
				model.BillToAddressID,
				model.Comment,
				model.CreditCardApprovalCode,
				model.CreditCardID,
				model.CurrencyRateID,
				model.CustomerID,
				model.DueDate,
				model.Freight,
				model.ModifiedDate,
				model.OnlineOrderFlag,
				model.OrderDate,
				model.PurchaseOrderNumber,
				model.RevisionNumber,
				model.Rowguid,
				model.SalesOrderNumber,
				model.SalesPersonID,
				model.ShipDate,
				model.ShipMethodID,
				model.ShipToAddressID,
				model.Status,
				model.SubTotal,
				model.TaxAmt,
				model.TerritoryID,
				model.TotalDue);
			return item;
		}

		public virtual ApiSalesOrderHeaderServerResponseModel MapEntityToModel(
			SalesOrderHeader item)
		{
			var model = new ApiSalesOrderHeaderServerResponseModel();

			model.SetProperties(item.SalesOrderID,
			                    item.AccountNumber,
			                    item.BillToAddressID,
			                    item.Comment,
			                    item.CreditCardApprovalCode,
			                    item.CreditCardID,
			                    item.CurrencyRateID,
			                    item.CustomerID,
			                    item.DueDate,
			                    item.Freight,
			                    item.ModifiedDate,
			                    item.OnlineOrderFlag,
			                    item.OrderDate,
			                    item.PurchaseOrderNumber,
			                    item.RevisionNumber,
			                    item.Rowguid,
			                    item.SalesOrderNumber,
			                    item.SalesPersonID,
			                    item.ShipDate,
			                    item.ShipMethodID,
			                    item.ShipToAddressID,
			                    item.Status,
			                    item.SubTotal,
			                    item.TaxAmt,
			                    item.TerritoryID,
			                    item.TotalDue);
			if (item.CreditCardIDNavigation != null)
			{
				var creditCardIDModel = new ApiCreditCardServerResponseModel();
				creditCardIDModel.SetProperties(
					item.CreditCardIDNavigation.CreditCardID,
					item.CreditCardIDNavigation.CardNumber,
					item.CreditCardIDNavigation.CardType,
					item.CreditCardIDNavigation.ExpMonth,
					item.CreditCardIDNavigation.ExpYear,
					item.CreditCardIDNavigation.ModifiedDate);

				model.SetCreditCardIDNavigation(creditCardIDModel);
			}

			if (item.CurrencyRateIDNavigation != null)
			{
				var currencyRateIDModel = new ApiCurrencyRateServerResponseModel();
				currencyRateIDModel.SetProperties(
					item.CurrencyRateIDNavigation.CurrencyRateID,
					item.CurrencyRateIDNavigation.AverageRate,
					item.CurrencyRateIDNavigation.CurrencyRateDate,
					item.CurrencyRateIDNavigation.EndOfDayRate,
					item.CurrencyRateIDNavigation.FromCurrencyCode,
					item.CurrencyRateIDNavigation.ModifiedDate,
					item.CurrencyRateIDNavigation.ToCurrencyCode);

				model.SetCurrencyRateIDNavigation(currencyRateIDModel);
			}

			if (item.CustomerIDNavigation != null)
			{
				var customerIDModel = new ApiCustomerServerResponseModel();
				customerIDModel.SetProperties(
					item.CustomerIDNavigation.CustomerID,
					item.CustomerIDNavigation.AccountNumber,
					item.CustomerIDNavigation.ModifiedDate,
					item.CustomerIDNavigation.PersonID,
					item.CustomerIDNavigation.Rowguid,
					item.CustomerIDNavigation.StoreID,
					item.CustomerIDNavigation.TerritoryID);

				model.SetCustomerIDNavigation(customerIDModel);
			}

			if (item.SalesPersonIDNavigation != null)
			{
				var salesPersonIDModel = new ApiSalesPersonServerResponseModel();
				salesPersonIDModel.SetProperties(
					item.SalesPersonIDNavigation.BusinessEntityID,
					item.SalesPersonIDNavigation.Bonus,
					item.SalesPersonIDNavigation.CommissionPct,
					item.SalesPersonIDNavigation.ModifiedDate,
					item.SalesPersonIDNavigation.Rowguid,
					item.SalesPersonIDNavigation.SalesLastYear,
					item.SalesPersonIDNavigation.SalesQuota,
					item.SalesPersonIDNavigation.SalesYTD,
					item.SalesPersonIDNavigation.TerritoryID);

				model.SetSalesPersonIDNavigation(salesPersonIDModel);
			}

			if (item.TerritoryIDNavigation != null)
			{
				var territoryIDModel = new ApiSalesTerritoryServerResponseModel();
				territoryIDModel.SetProperties(
					item.TerritoryIDNavigation.TerritoryID,
					item.TerritoryIDNavigation.CostLastYear,
					item.TerritoryIDNavigation.CostYTD,
					item.TerritoryIDNavigation.CountryRegionCode,
					item.TerritoryIDNavigation.ModifiedDate,
					item.TerritoryIDNavigation.Name,
					item.TerritoryIDNavigation.Rowguid,
					item.TerritoryIDNavigation.SalesLastYear,
					item.TerritoryIDNavigation.SalesYTD);

				model.SetTerritoryIDNavigation(territoryIDModel);
			}

			return model;
		}

		public virtual List<ApiSalesOrderHeaderServerResponseModel> MapEntityToModel(
			List<SalesOrderHeader> items)
		{
			List<ApiSalesOrderHeaderServerResponseModel> response = new List<ApiSalesOrderHeaderServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a8b685f9443cee27de037ac9abc1672b</Hash>
</Codenesium>*/