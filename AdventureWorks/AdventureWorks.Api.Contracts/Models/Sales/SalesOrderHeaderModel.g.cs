using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesOrderHeaderModel
	{
		public SalesOrderHeaderModel()
		{}

		public SalesOrderHeaderModel(
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
			this.RevisionNumber = revisionNumber.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.Status = status.ToInt();
			this.OnlineOrderFlag = onlineOrderFlag.ToBoolean();
			this.SalesOrderNumber = salesOrderNumber.ToString();
			this.PurchaseOrderNumber = purchaseOrderNumber.ToString();
			this.AccountNumber = accountNumber.ToString();
			this.CustomerID = customerID.ToInt();
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.BillToAddressID = billToAddressID.ToInt();
			this.ShipToAddressID = shipToAddressID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.CreditCardID = creditCardID.ToNullableInt();
			this.CreditCardApprovalCode = creditCardApprovalCode.ToString();
			this.CurrencyRateID = currencyRateID.ToNullableInt();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.Freight = freight.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
			this.Comment = comment.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int revisionNumber;

		[Required]
		public int RevisionNumber
		{
			get
			{
				return this.revisionNumber;
			}

			set
			{
				this.revisionNumber = value;
			}
		}

		private DateTime orderDate;

		[Required]
		public DateTime OrderDate
		{
			get
			{
				return this.orderDate;
			}

			set
			{
				this.orderDate = value;
			}
		}

		private DateTime dueDate;

		[Required]
		public DateTime DueDate
		{
			get
			{
				return this.dueDate;
			}

			set
			{
				this.dueDate = value;
			}
		}

		private Nullable<DateTime> shipDate;

		public Nullable<DateTime> ShipDate
		{
			get
			{
				return this.shipDate.IsEmptyOrZeroOrNull() ? null : this.shipDate;
			}

			set
			{
				this.shipDate = value;
			}
		}

		private int status;

		[Required]
		public int Status
		{
			get
			{
				return this.status;
			}

			set
			{
				this.status = value;
			}
		}

		private bool onlineOrderFlag;

		[Required]
		public bool OnlineOrderFlag
		{
			get
			{
				return this.onlineOrderFlag;
			}

			set
			{
				this.onlineOrderFlag = value;
			}
		}

		private string salesOrderNumber;

		[Required]
		public string SalesOrderNumber
		{
			get
			{
				return this.salesOrderNumber;
			}

			set
			{
				this.salesOrderNumber = value;
			}
		}

		private string purchaseOrderNumber;

		public string PurchaseOrderNumber
		{
			get
			{
				return this.purchaseOrderNumber.IsEmptyOrZeroOrNull() ? null : this.purchaseOrderNumber;
			}

			set
			{
				this.purchaseOrderNumber = value;
			}
		}

		private string accountNumber;

		public string AccountNumber
		{
			get
			{
				return this.accountNumber.IsEmptyOrZeroOrNull() ? null : this.accountNumber;
			}

			set
			{
				this.accountNumber = value;
			}
		}

		private int customerID;

		[Required]
		public int CustomerID
		{
			get
			{
				return this.customerID;
			}

			set
			{
				this.customerID = value;
			}
		}

		private Nullable<int> salesPersonID;

		public Nullable<int> SalesPersonID
		{
			get
			{
				return this.salesPersonID.IsEmptyOrZeroOrNull() ? null : this.salesPersonID;
			}

			set
			{
				this.salesPersonID = value;
			}
		}

		private Nullable<int> territoryID;

		public Nullable<int> TerritoryID
		{
			get
			{
				return this.territoryID.IsEmptyOrZeroOrNull() ? null : this.territoryID;
			}

			set
			{
				this.territoryID = value;
			}
		}

		private int billToAddressID;

		[Required]
		public int BillToAddressID
		{
			get
			{
				return this.billToAddressID;
			}

			set
			{
				this.billToAddressID = value;
			}
		}

		private int shipToAddressID;

		[Required]
		public int ShipToAddressID
		{
			get
			{
				return this.shipToAddressID;
			}

			set
			{
				this.shipToAddressID = value;
			}
		}

		private int shipMethodID;

		[Required]
		public int ShipMethodID
		{
			get
			{
				return this.shipMethodID;
			}

			set
			{
				this.shipMethodID = value;
			}
		}

		private Nullable<int> creditCardID;

		public Nullable<int> CreditCardID
		{
			get
			{
				return this.creditCardID.IsEmptyOrZeroOrNull() ? null : this.creditCardID;
			}

			set
			{
				this.creditCardID = value;
			}
		}

		private string creditCardApprovalCode;

		public string CreditCardApprovalCode
		{
			get
			{
				return this.creditCardApprovalCode.IsEmptyOrZeroOrNull() ? null : this.creditCardApprovalCode;
			}

			set
			{
				this.creditCardApprovalCode = value;
			}
		}

		private Nullable<int> currencyRateID;

		public Nullable<int> CurrencyRateID
		{
			get
			{
				return this.currencyRateID.IsEmptyOrZeroOrNull() ? null : this.currencyRateID;
			}

			set
			{
				this.currencyRateID = value;
			}
		}

		private decimal subTotal;

		[Required]
		public decimal SubTotal
		{
			get
			{
				return this.subTotal;
			}

			set
			{
				this.subTotal = value;
			}
		}

		private decimal taxAmt;

		[Required]
		public decimal TaxAmt
		{
			get
			{
				return this.taxAmt;
			}

			set
			{
				this.taxAmt = value;
			}
		}

		private decimal freight;

		[Required]
		public decimal Freight
		{
			get
			{
				return this.freight;
			}

			set
			{
				this.freight = value;
			}
		}

		private decimal totalDue;

		[Required]
		public decimal TotalDue
		{
			get
			{
				return this.totalDue;
			}

			set
			{
				this.totalDue = value;
			}
		}

		private string comment;

		public string Comment
		{
			get
			{
				return this.comment.IsEmptyOrZeroOrNull() ? null : this.comment;
			}

			set
			{
				this.comment = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e2603df1e7023c7edff19fd48f38ff82</Hash>
</Codenesium>*/