using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesOrderHeader
	{
		public POCOSalesOrderHeader()
		{}

		public POCOSalesOrderHeader(int salesOrderID,
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
			this.RevisionNumber = revisionNumber;
			this.OrderDate = orderDate.ToDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.Status = status;
			this.OnlineOrderFlag = onlineOrderFlag;
			this.SalesOrderNumber = salesOrderNumber;
			this.PurchaseOrderNumber = purchaseOrderNumber;
			this.AccountNumber = accountNumber;
			this.CustomerID = customerID.ToInt();
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.BillToAddressID = billToAddressID.ToInt();
			this.ShipToAddressID = shipToAddressID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.CreditCardID = creditCardID.ToNullableInt();
			this.CreditCardApprovalCode = creditCardApprovalCode;
			this.CurrencyRateID = currencyRateID.ToNullableInt();
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.Freight = freight;
			this.TotalDue = totalDue;
			this.Comment = comment;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int SalesOrderID {get; set;}
		public int RevisionNumber {get; set;}
		public DateTime OrderDate {get; set;}
		public DateTime DueDate {get; set;}
		public Nullable<DateTime> ShipDate {get; set;}
		public int Status {get; set;}
		public bool OnlineOrderFlag {get; set;}
		public string SalesOrderNumber {get; set;}
		public string PurchaseOrderNumber {get; set;}
		public string AccountNumber {get; set;}
		public int CustomerID {get; set;}
		public Nullable<int> SalesPersonID {get; set;}
		public Nullable<int> TerritoryID {get; set;}
		public int BillToAddressID {get; set;}
		public int ShipToAddressID {get; set;}
		public int ShipMethodID {get; set;}
		public Nullable<int> CreditCardID {get; set;}
		public string CreditCardApprovalCode {get; set;}
		public Nullable<int> CurrencyRateID {get; set;}
		public decimal SubTotal {get; set;}
		public decimal TaxAmt {get; set;}
		public decimal Freight {get; set;}
		public decimal TotalDue {get; set;}
		public string Comment {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue {get; set;} = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRevisionNumberValue {get; set;} = true;

		public bool ShouldSerializeRevisionNumber()
		{
			return ShouldSerializeRevisionNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderDateValue {get; set;} = true;

		public bool ShouldSerializeOrderDate()
		{
			return ShouldSerializeOrderDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue {get; set;} = true;

		public bool ShouldSerializeDueDate()
		{
			return ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipDateValue {get; set;} = true;

		public bool ShouldSerializeShipDate()
		{
			return ShouldSerializeShipDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStatusValue {get; set;} = true;

		public bool ShouldSerializeStatus()
		{
			return ShouldSerializeStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOnlineOrderFlagValue {get; set;} = true;

		public bool ShouldSerializeOnlineOrderFlag()
		{
			return ShouldSerializeOnlineOrderFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderNumberValue {get; set;} = true;

		public bool ShouldSerializeSalesOrderNumber()
		{
			return ShouldSerializeSalesOrderNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderNumberValue {get; set;} = true;

		public bool ShouldSerializePurchaseOrderNumber()
		{
			return ShouldSerializePurchaseOrderNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue {get; set;} = true;

		public bool ShouldSerializeAccountNumber()
		{
			return ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCustomerIDValue {get; set;} = true;

		public bool ShouldSerializeCustomerID()
		{
			return ShouldSerializeCustomerIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonIDValue {get; set;} = true;

		public bool ShouldSerializeSalesPersonID()
		{
			return ShouldSerializeSalesPersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue {get; set;} = true;

		public bool ShouldSerializeTerritoryID()
		{
			return ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBillToAddressIDValue {get; set;} = true;

		public bool ShouldSerializeBillToAddressID()
		{
			return ShouldSerializeBillToAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipToAddressIDValue {get; set;} = true;

		public bool ShouldSerializeShipToAddressID()
		{
			return ShouldSerializeShipToAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue {get; set;} = true;

		public bool ShouldSerializeShipMethodID()
		{
			return ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue {get; set;} = true;

		public bool ShouldSerializeCreditCardID()
		{
			return ShouldSerializeCreditCardIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardApprovalCodeValue {get; set;} = true;

		public bool ShouldSerializeCreditCardApprovalCode()
		{
			return ShouldSerializeCreditCardApprovalCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateIDValue {get; set;} = true;

		public bool ShouldSerializeCurrencyRateID()
		{
			return ShouldSerializeCurrencyRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSubTotalValue {get; set;} = true;

		public bool ShouldSerializeSubTotal()
		{
			return ShouldSerializeSubTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxAmtValue {get; set;} = true;

		public bool ShouldSerializeTaxAmt()
		{
			return ShouldSerializeTaxAmtValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFreightValue {get; set;} = true;

		public bool ShouldSerializeFreight()
		{
			return ShouldSerializeFreightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTotalDueValue {get; set;} = true;

		public bool ShouldSerializeTotalDue()
		{
			return ShouldSerializeTotalDueValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommentValue {get; set;} = true;

		public bool ShouldSerializeComment()
		{
			return ShouldSerializeCommentValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>b7bdafa48a00768c05cfa52db9e5cd2d</Hash>
</Codenesium>*/