using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeader", Schema="Sales")]
	public partial class SalesOrderHeader : AbstractEntity
	{
		public SalesOrderHeader()
		{
		}

		public virtual void SetProperties(
			int salesOrderID,
			string accountNumber,
			int billToAddressID,
			string comment,
			string creditCardApprovalCode,
			int? creditCardID,
			int? currencyRateID,
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
			int? salesPersonID,
			DateTime? shipDate,
			int shipMethodID,
			int shipToAddressID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			int? territoryID,
			decimal totalDue)
		{
			this.SalesOrderID = salesOrderID;
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
		}

		[MaxLength(15)]
		[Column("AccountNumber")]
		public virtual string AccountNumber { get; private set; }

		[Column("BillToAddressID")]
		public virtual int BillToAddressID { get; private set; }

		[MaxLength(128)]
		[Column("Comment")]
		public virtual string Comment { get; private set; }

		[MaxLength(15)]
		[Column("CreditCardApprovalCode")]
		public virtual string CreditCardApprovalCode { get; private set; }

		[Column("CreditCardID")]
		public virtual int? CreditCardID { get; private set; }

		[Column("CurrencyRateID")]
		public virtual int? CurrencyRateID { get; private set; }

		[Column("CustomerID")]
		public virtual int CustomerID { get; private set; }

		[Column("DueDate")]
		public virtual DateTime DueDate { get; private set; }

		[Column("Freight")]
		public virtual decimal Freight { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("OnlineOrderFlag")]
		public virtual bool OnlineOrderFlag { get; private set; }

		[Column("OrderDate")]
		public virtual DateTime OrderDate { get; private set; }

		[MaxLength(25)]
		[Column("PurchaseOrderNumber")]
		public virtual string PurchaseOrderNumber { get; private set; }

		[Column("RevisionNumber")]
		public virtual int RevisionNumber { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Key]
		[Column("SalesOrderID")]
		public virtual int SalesOrderID { get; private set; }

		[MaxLength(25)]
		[Column("SalesOrderNumber")]
		public virtual string SalesOrderNumber { get; private set; }

		[Column("SalesPersonID")]
		public virtual int? SalesPersonID { get; private set; }

		[Column("ShipDate")]
		public virtual DateTime? ShipDate { get; private set; }

		[Column("ShipMethodID")]
		public virtual int ShipMethodID { get; private set; }

		[Column("ShipToAddressID")]
		public virtual int ShipToAddressID { get; private set; }

		[Column("Status")]
		public virtual int Status { get; private set; }

		[Column("SubTotal")]
		public virtual decimal SubTotal { get; private set; }

		[Column("TaxAmt")]
		public virtual decimal TaxAmt { get; private set; }

		[Column("TerritoryID")]
		public virtual int? TerritoryID { get; private set; }

		[Column("TotalDue")]
		public virtual decimal TotalDue { get; private set; }

		[ForeignKey("CreditCardID")]
		public virtual CreditCard CreditCardIDNavigation { get; private set; }

		public void SetCreditCardIDNavigation(CreditCard item)
		{
			this.CreditCardIDNavigation = item;
		}

		[ForeignKey("CurrencyRateID")]
		public virtual CurrencyRate CurrencyRateIDNavigation { get; private set; }

		public void SetCurrencyRateIDNavigation(CurrencyRate item)
		{
			this.CurrencyRateIDNavigation = item;
		}

		[ForeignKey("CustomerID")]
		public virtual Customer CustomerIDNavigation { get; private set; }

		public void SetCustomerIDNavigation(Customer item)
		{
			this.CustomerIDNavigation = item;
		}

		[ForeignKey("SalesPersonID")]
		public virtual SalesPerson SalesPersonIDNavigation { get; private set; }

		public void SetSalesPersonIDNavigation(SalesPerson item)
		{
			this.SalesPersonIDNavigation = item;
		}

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory TerritoryIDNavigation { get; private set; }

		public void SetTerritoryIDNavigation(SalesTerritory item)
		{
			this.TerritoryIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>442cd372b839327d6d592784a93b63ce</Hash>
</Codenesium>*/