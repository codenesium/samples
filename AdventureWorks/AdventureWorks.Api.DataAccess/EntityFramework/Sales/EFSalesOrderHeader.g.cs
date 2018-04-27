using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeader", Schema="Sales")]
	public partial class EFSalesOrderHeader: AbstractEntityFrameworkPOCO
	{
		public EFSalesOrderHeader()
		{}

		public void SetProperties(
			int salesOrderID,
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
			this.AccountNumber = accountNumber.ToString();
			this.BillToAddressID = billToAddressID.ToInt();
			this.Comment = comment.ToString();
			this.CreditCardApprovalCode = creditCardApprovalCode.ToString();
			this.CreditCardID = creditCardID.ToNullableInt();
			this.CurrencyRateID = currencyRateID.ToNullableInt();
			this.CustomerID = customerID.ToInt();
			this.DueDate = dueDate.ToDateTime();
			this.Freight = freight.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OnlineOrderFlag = onlineOrderFlag.ToBoolean();
			this.OrderDate = orderDate.ToDateTime();
			this.PurchaseOrderNumber = purchaseOrderNumber.ToString();
			this.RevisionNumber = revisionNumber.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesOrderNumber = salesOrderNumber.ToString();
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipToAddressID = shipToAddressID.ToInt();
			this.Status = status.ToInt();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.TerritoryID = territoryID.ToNullableInt();
			this.TotalDue = totalDue.ToDecimal();
		}

		[Column("AccountNumber", TypeName="nvarchar(15)")]
		public string AccountNumber { get; set; }

		[Column("BillToAddressID", TypeName="int")]
		public int BillToAddressID { get; set; }

		[Column("Comment", TypeName="nvarchar(128)")]
		public string Comment { get; set; }

		[Column("CreditCardApprovalCode", TypeName="varchar(15)")]
		public string CreditCardApprovalCode { get; set; }

		[Column("CreditCardID", TypeName="int")]
		public Nullable<int> CreditCardID { get; set; }

		[Column("CurrencyRateID", TypeName="int")]
		public Nullable<int> CurrencyRateID { get; set; }

		[Column("CustomerID", TypeName="int")]
		public int CustomerID { get; set; }

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate { get; set; }

		[Column("Freight", TypeName="money")]
		public decimal Freight { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OnlineOrderFlag", TypeName="bit")]
		public bool OnlineOrderFlag { get; set; }

		[Column("OrderDate", TypeName="datetime")]
		public DateTime OrderDate { get; set; }

		[Column("PurchaseOrderNumber", TypeName="nvarchar(25)")]
		public string PurchaseOrderNumber { get; set; }

		[Column("RevisionNumber", TypeName="tinyint")]
		public int RevisionNumber { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Key]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID { get; set; }

		[Column("SalesOrderNumber", TypeName="nvarchar(25)")]
		public string SalesOrderNumber { get; set; }

		[Column("SalesPersonID", TypeName="int")]
		public Nullable<int> SalesPersonID { get; set; }

		[Column("ShipDate", TypeName="datetime")]
		public Nullable<DateTime> ShipDate { get; set; }

		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID { get; set; }

		[Column("ShipToAddressID", TypeName="int")]
		public int ShipToAddressID { get; set; }

		[Column("Status", TypeName="tinyint")]
		public int Status { get; set; }

		[Column("SubTotal", TypeName="money")]
		public decimal SubTotal { get; set; }

		[Column("TaxAmt", TypeName="money")]
		public decimal TaxAmt { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; set; }

		[Column("TotalDue", TypeName="money")]
		public decimal TotalDue { get; set; }

		[ForeignKey("BillToAddressID")]
		public virtual EFAddress Address { get; set; }

		[ForeignKey("CreditCardID")]
		public virtual EFCreditCard CreditCard { get; set; }

		[ForeignKey("CurrencyRateID")]
		public virtual EFCurrencyRate CurrencyRate { get; set; }

		[ForeignKey("CustomerID")]
		public virtual EFCustomer Customer { get; set; }

		[ForeignKey("SalesPersonID")]
		public virtual EFSalesPerson SalesPerson { get; set; }

		[ForeignKey("ShipMethodID")]
		public virtual EFShipMethod ShipMethod { get; set; }

		[ForeignKey("ShipToAddressID")]
		public virtual EFAddress Address1 { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>41c8d7a0aaabf92ea618db70dd2494ec</Hash>
</Codenesium>*/