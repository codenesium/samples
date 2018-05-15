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
			string accountNumber,
			int billToAddressID,
			string comment,
			string creditCardApprovalCode,
			Nullable<int> creditCardID,
			Nullable<int> currencyRateID,
			int customerID,
			DateTime dueDate,
			decimal freight,
			DateTime modifiedDate,
			bool onlineOrderFlag,
			DateTime orderDate,
			string purchaseOrderNumber,
			int revisionNumber,
			Guid rowguid,
			int salesOrderID,
			string salesOrderNumber,
			Nullable<int> salesPersonID,
			Nullable<DateTime> shipDate,
			int shipMethodID,
			int shipToAddressID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			Nullable<int> territoryID,
			decimal totalDue)
		{
			this.AccountNumber = accountNumber;
			this.BillToAddressID = billToAddressID.ToInt();
			this.Comment = comment;
			this.CreditCardApprovalCode = creditCardApprovalCode;
			this.DueDate = dueDate.ToDateTime();
			this.Freight = freight.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OnlineOrderFlag = onlineOrderFlag.ToBoolean();
			this.OrderDate = orderDate.ToDateTime();
			this.PurchaseOrderNumber = purchaseOrderNumber;
			this.RevisionNumber = revisionNumber.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesOrderNumber = salesOrderNumber;
			this.ShipDate = shipDate.ToNullableDateTime();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipToAddressID = shipToAddressID.ToInt();
			this.Status = status.ToInt();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();

			this.CreditCardID = new ReferenceEntity<Nullable<int>>(creditCardID,
			                                                       nameof(ApiResponse.CreditCards));
			this.CurrencyRateID = new ReferenceEntity<Nullable<int>>(currencyRateID,
			                                                         nameof(ApiResponse.CurrencyRates));
			this.CustomerID = new ReferenceEntity<int>(customerID,
			                                           nameof(ApiResponse.Customers));
			this.SalesPersonID = new ReferenceEntity<Nullable<int>>(salesPersonID,
			                                                        nameof(ApiResponse.SalesPersons));
			this.TerritoryID = new ReferenceEntity<Nullable<int>>(territoryID,
			                                                      nameof(ApiResponse.SalesTerritories));
		}

		public string AccountNumber { get; set; }
		public int BillToAddressID { get; set; }
		public string Comment { get; set; }
		public string CreditCardApprovalCode { get; set; }
		public ReferenceEntity<Nullable<int>> CreditCardID { get; set; }
		public ReferenceEntity<Nullable<int>> CurrencyRateID { get; set; }
		public ReferenceEntity<int> CustomerID { get; set; }
		public DateTime DueDate { get; set; }
		public decimal Freight { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool OnlineOrderFlag { get; set; }
		public DateTime OrderDate { get; set; }
		public string PurchaseOrderNumber { get; set; }
		public int RevisionNumber { get; set; }
		public Guid Rowguid { get; set; }
		public int SalesOrderID { get; set; }
		public string SalesOrderNumber { get; set; }
		public ReferenceEntity<Nullable<int>> SalesPersonID { get; set; }
		public Nullable<DateTime> ShipDate { get; set; }
		public int ShipMethodID { get; set; }
		public int ShipToAddressID { get; set; }
		public int Status { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TaxAmt { get; set; }
		public ReferenceEntity<Nullable<int>> TerritoryID { get; set; }
		public decimal TotalDue { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue { get; set; } = true;

		public bool ShouldSerializeAccountNumber()
		{
			return this.ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBillToAddressIDValue { get; set; } = true;

		public bool ShouldSerializeBillToAddressID()
		{
			return this.ShouldSerializeBillToAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommentValue { get; set; } = true;

		public bool ShouldSerializeComment()
		{
			return this.ShouldSerializeCommentValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardApprovalCodeValue { get; set; } = true;

		public bool ShouldSerializeCreditCardApprovalCode()
		{
			return this.ShouldSerializeCreditCardApprovalCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue { get; set; } = true;

		public bool ShouldSerializeCreditCardID()
		{
			return this.ShouldSerializeCreditCardIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateIDValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRateID()
		{
			return this.ShouldSerializeCurrencyRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCustomerIDValue { get; set; } = true;

		public bool ShouldSerializeCustomerID()
		{
			return this.ShouldSerializeCustomerIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue { get; set; } = true;

		public bool ShouldSerializeDueDate()
		{
			return this.ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFreightValue { get; set; } = true;

		public bool ShouldSerializeFreight()
		{
			return this.ShouldSerializeFreightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOnlineOrderFlagValue { get; set; } = true;

		public bool ShouldSerializeOnlineOrderFlag()
		{
			return this.ShouldSerializeOnlineOrderFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderDateValue { get; set; } = true;

		public bool ShouldSerializeOrderDate()
		{
			return this.ShouldSerializeOrderDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderNumberValue { get; set; } = true;

		public bool ShouldSerializePurchaseOrderNumber()
		{
			return this.ShouldSerializePurchaseOrderNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRevisionNumberValue { get; set; } = true;

		public bool ShouldSerializeRevisionNumber()
		{
			return this.ShouldSerializeRevisionNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderNumberValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderNumber()
		{
			return this.ShouldSerializeSalesOrderNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesPersonID()
		{
			return this.ShouldSerializeSalesPersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipDateValue { get; set; } = true;

		public bool ShouldSerializeShipDate()
		{
			return this.ShouldSerializeShipDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

		public bool ShouldSerializeShipMethodID()
		{
			return this.ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipToAddressIDValue { get; set; } = true;

		public bool ShouldSerializeShipToAddressID()
		{
			return this.ShouldSerializeShipToAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStatusValue { get; set; } = true;

		public bool ShouldSerializeStatus()
		{
			return this.ShouldSerializeStatusValue;
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
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTotalDueValue { get; set; } = true;

		public bool ShouldSerializeTotalDue()
		{
			return this.ShouldSerializeTotalDueValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAccountNumberValue = false;
			this.ShouldSerializeBillToAddressIDValue = false;
			this.ShouldSerializeCommentValue = false;
			this.ShouldSerializeCreditCardApprovalCodeValue = false;
			this.ShouldSerializeCreditCardIDValue = false;
			this.ShouldSerializeCurrencyRateIDValue = false;
			this.ShouldSerializeCustomerIDValue = false;
			this.ShouldSerializeDueDateValue = false;
			this.ShouldSerializeFreightValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOnlineOrderFlagValue = false;
			this.ShouldSerializeOrderDateValue = false;
			this.ShouldSerializePurchaseOrderNumberValue = false;
			this.ShouldSerializeRevisionNumberValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSalesOrderNumberValue = false;
			this.ShouldSerializeSalesPersonIDValue = false;
			this.ShouldSerializeShipDateValue = false;
			this.ShouldSerializeShipMethodIDValue = false;
			this.ShouldSerializeShipToAddressIDValue = false;
			this.ShouldSerializeStatusValue = false;
			this.ShouldSerializeSubTotalValue = false;
			this.ShouldSerializeTaxAmtValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeTotalDueValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>018ee185bb37657fd127a8be1d6c1ed6</Hash>
</Codenesium>*/