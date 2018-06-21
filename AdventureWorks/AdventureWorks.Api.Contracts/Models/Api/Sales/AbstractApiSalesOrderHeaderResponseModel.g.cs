using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesOrderHeaderResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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
                        this.BillToAddressID = billToAddressID;
                        this.Comment = comment;
                        this.CreditCardApprovalCode = creditCardApprovalCode;
                        this.CreditCardID = creditCardID;
                        this.CurrencyRateID = currencyRateID;
                        this.CustomerID = customerID;
                        this.DueDate = dueDate;
                        this.Freight = freight;
                        this.ModifiedDate = modifiedDate;
                        this.OnlineOrderFlag = onlineOrderFlag;
                        this.OrderDate = orderDate;
                        this.PurchaseOrderNumber = purchaseOrderNumber;
                        this.RevisionNumber = revisionNumber;
                        this.Rowguid = rowguid;
                        this.SalesOrderID = salesOrderID;
                        this.SalesOrderNumber = salesOrderNumber;
                        this.SalesPersonID = salesPersonID;
                        this.ShipDate = shipDate;
                        this.ShipMethodID = shipMethodID;
                        this.ShipToAddressID = shipToAddressID;
                        this.Status = status;
                        this.SubTotal = subTotal;
                        this.TaxAmt = taxAmt;
                        this.TerritoryID = territoryID;
                        this.TotalDue = totalDue;

                        this.CreditCardIDEntity = nameof(ApiResponse.CreditCards);
                        this.CurrencyRateIDEntity = nameof(ApiResponse.CurrencyRates);
                        this.CustomerIDEntity = nameof(ApiResponse.Customers);
                        this.SalesPersonIDEntity = nameof(ApiResponse.SalesPersons);
                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public string AccountNumber { get; private set; }

                public int BillToAddressID { get; private set; }

                public string Comment { get; private set; }

                public string CreditCardApprovalCode { get; private set; }

                public Nullable<int> CreditCardID { get; private set; }

                public string CreditCardIDEntity { get; set; }

                public Nullable<int> CurrencyRateID { get; private set; }

                public string CurrencyRateIDEntity { get; set; }

                public int CustomerID { get; private set; }

                public string CustomerIDEntity { get; set; }

                public DateTime DueDate { get; private set; }

                public decimal Freight { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public bool OnlineOrderFlag { get; private set; }

                public DateTime OrderDate { get; private set; }

                public string PurchaseOrderNumber { get; private set; }

                public int RevisionNumber { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SalesOrderID { get; private set; }

                public string SalesOrderNumber { get; private set; }

                public Nullable<int> SalesPersonID { get; private set; }

                public string SalesPersonIDEntity { get; set; }

                public Nullable<DateTime> ShipDate { get; private set; }

                public int ShipMethodID { get; private set; }

                public int ShipToAddressID { get; private set; }

                public int Status { get; private set; }

                public decimal SubTotal { get; private set; }

                public decimal TaxAmt { get; private set; }

                public Nullable<int> TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }

                public decimal TotalDue { get; private set; }

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

                public virtual void DisableAllFields()
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
    <Hash>556763e9d3509f1dd3b8694dfd11eec0</Hash>
</Codenesium>*/