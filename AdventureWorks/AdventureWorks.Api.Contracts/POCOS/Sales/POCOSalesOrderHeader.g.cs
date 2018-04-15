using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesOrderHeader
	{
		public POCOSalesOrderHeader()
		{}

		public POCOSalesOrderHeader(
			int salesOrderID,
			int revisionNumber,
			DateTime orderDate,
			DateTime dueDate,
			Nullable<DateTime> shipDate,
			int status,
			bool onlineOrderFlag,
			string salesOrderNumber,
			string purchaseOrderNumber,
			string accountNumber,
			int customerID,
			Nullable<int> salesPersonID,
			Nullable<int> territoryID,
			int billToAddressID,
			int shipToAddressID,
			int shipMethodID,
			Nullable<int> creditCardID,
			string creditCardApprovalCode,
			Nullable<int> currencyRateID,
			decimal subTotal,
			decimal taxAmt,
			decimal freight,
			decimal totalDue,
			string comment,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SalesOrderID = salesOrderID.ToInt();
			this.RevisionNumber = revisionNumber.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.Status = status.ToInt();
			this.OnlineOrderFlag = onlineOrderFlag.ToBoolean();
			this.SalesOrderNumber = salesOrderNumber.ToString();
			this.PurchaseOrderNumber = purchaseOrderNumber.ToString();
			this.AccountNumber = accountNumber.ToString();
			this.CreditCardApprovalCode = creditCardApprovalCode.ToString();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.Freight = freight.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
			this.Comment = comment.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.CustomerID = new ReferenceEntity<int>(customerID,
			                                           nameof(ApiResponse.Customers));
			this.SalesPersonID = new ReferenceEntity<Nullable<int>>(salesPersonID,
			                                                        nameof(ApiResponse.SalesPersons));
			this.TerritoryID = new ReferenceEntity<Nullable<int>>(territoryID,
			                                                      nameof(ApiResponse.SalesTerritories));
			this.BillToAddressID = new ReferenceEntity<int>(billToAddressID,
			                                                nameof(ApiResponse.Addresses));
			this.ShipToAddressID = new ReferenceEntity<int>(shipToAddressID,
			                                                nameof(ApiResponse.Addresses));
			this.ShipMethodID = new ReferenceEntity<int>(shipMethodID,
			                                             nameof(ApiResponse.ShipMethods));
			this.CreditCardID = new ReferenceEntity<Nullable<int>>(creditCardID,
			                                                       nameof(ApiResponse.CreditCards));
			this.CurrencyRateID = new ReferenceEntity<Nullable<int>>(currencyRateID,
			                                                         nameof(ApiResponse.CurrencyRates));
		}

		public int SalesOrderID { get; set; }
		public int RevisionNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DueDate { get; set; }
		public Nullable<DateTime> ShipDate { get; set; }
		public int Status { get; set; }
		public bool OnlineOrderFlag { get; set; }
		public string SalesOrderNumber { get; set; }
		public string PurchaseOrderNumber { get; set; }
		public string AccountNumber { get; set; }
		public ReferenceEntity<int> CustomerID { get; set; }
		public ReferenceEntity<Nullable<int>> SalesPersonID { get; set; }
		public ReferenceEntity<Nullable<int>> TerritoryID { get; set; }
		public ReferenceEntity<int> BillToAddressID { get; set; }
		public ReferenceEntity<int> ShipToAddressID { get; set; }
		public ReferenceEntity<int> ShipMethodID { get; set; }
		public ReferenceEntity<Nullable<int>> CreditCardID { get; set; }
		public string CreditCardApprovalCode { get; set; }
		public ReferenceEntity<Nullable<int>> CurrencyRateID { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TaxAmt { get; set; }
		public decimal Freight { get; set; }
		public decimal TotalDue { get; set; }
		public string Comment { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRevisionNumberValue { get; set; } = true;

		public bool ShouldSerializeRevisionNumber()
		{
			return this.ShouldSerializeRevisionNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderDateValue { get; set; } = true;

		public bool ShouldSerializeOrderDate()
		{
			return this.ShouldSerializeOrderDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue { get; set; } = true;

		public bool ShouldSerializeDueDate()
		{
			return this.ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipDateValue { get; set; } = true;

		public bool ShouldSerializeShipDate()
		{
			return this.ShouldSerializeShipDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStatusValue { get; set; } = true;

		public bool ShouldSerializeStatus()
		{
			return this.ShouldSerializeStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOnlineOrderFlagValue { get; set; } = true;

		public bool ShouldSerializeOnlineOrderFlag()
		{
			return this.ShouldSerializeOnlineOrderFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderNumberValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderNumber()
		{
			return this.ShouldSerializeSalesOrderNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderNumberValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderNumber()
		{
			return this.ShouldSerializePurchaseOrderNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue { get; set; } = true;

		public bool ShouldSerializeAccountNumber()
		{
			return this.ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCustomerIDValue { get; set; } = true;

		public bool ShouldSerializeCustomerID()
		{
			return this.ShouldSerializeCustomerIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesPersonID()
		{
			return this.ShouldSerializeSalesPersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBillToAddressIDValue { get; set; } = true;

		public bool ShouldSerializeBillToAddressID()
		{
			return this.ShouldSerializeBillToAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipToAddressIDValue { get; set; } = true;

		public bool ShouldSerializeShipToAddressID()
		{
			return this.ShouldSerializeShipToAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

		public bool ShouldSerializeShipMethodID()
		{
			return this.ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue { get; set; } = true;

		public bool ShouldSerializeCreditCardID()
		{
			return this.ShouldSerializeCreditCardIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardApprovalCodeValue { get; set; } = true;

		public bool ShouldSerializeCreditCardApprovalCode()
		{
			return this.ShouldSerializeCreditCardApprovalCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateIDValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRateID()
		{
			return this.ShouldSerializeCurrencyRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSubTotalValue { get; set; } = true;

		public bool ShouldSerializeSubTotal()
		{
			return this.ShouldSerializeSubTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxAmtValue { get; set; } = true;

		public bool ShouldSerializeTaxAmt()
		{
			return this.ShouldSerializeTaxAmtValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFreightValue { get; set; } = true;

		public bool ShouldSerializeFreight()
		{
			return this.ShouldSerializeFreightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTotalDueValue { get; set; } = true;

		public bool ShouldSerializeTotalDue()
		{
			return this.ShouldSerializeTotalDueValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommentValue { get; set; } = true;

		public bool ShouldSerializeComment()
		{
			return this.ShouldSerializeCommentValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeRevisionNumberValue = false;
			this.ShouldSerializeOrderDateValue = false;
			this.ShouldSerializeDueDateValue = false;
			this.ShouldSerializeShipDateValue = false;
			this.ShouldSerializeStatusValue = false;
			this.ShouldSerializeOnlineOrderFlagValue = false;
			this.ShouldSerializeSalesOrderNumberValue = false;
			this.ShouldSerializePurchaseOrderNumberValue = false;
			this.ShouldSerializeAccountNumberValue = false;
			this.ShouldSerializeCustomerIDValue = false;
			this.ShouldSerializeSalesPersonIDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeBillToAddressIDValue = false;
			this.ShouldSerializeShipToAddressIDValue = false;
			this.ShouldSerializeShipMethodIDValue = false;
			this.ShouldSerializeCreditCardIDValue = false;
			this.ShouldSerializeCreditCardApprovalCodeValue = false;
			this.ShouldSerializeCurrencyRateIDValue = false;
			this.ShouldSerializeSubTotalValue = false;
			this.ShouldSerializeTaxAmtValue = false;
			this.ShouldSerializeFreightValue = false;
			this.ShouldSerializeTotalDueValue = false;
			this.ShouldSerializeCommentValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5c79b7e514996276f4ed133c5fc371af</Hash>
</Codenesium>*/