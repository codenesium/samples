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
		public SalesOrderHeaderModel(int revisionNumber,
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

		private int _revisionNumber;
		[Required]
		public int RevisionNumber
		{
			get
			{
				return _revisionNumber;
			}
			set
			{
				this._revisionNumber = value;
			}
		}

		private DateTime _orderDate;
		[Required]
		public DateTime OrderDate
		{
			get
			{
				return _orderDate;
			}
			set
			{
				this._orderDate = value;
			}
		}

		private DateTime _dueDate;
		[Required]
		public DateTime DueDate
		{
			get
			{
				return _dueDate;
			}
			set
			{
				this._dueDate = value;
			}
		}

		private Nullable<DateTime> _shipDate;
		public Nullable<DateTime> ShipDate
		{
			get
			{
				return _shipDate.IsEmptyOrZeroOrNull() ? null : _shipDate;
			}
			set
			{
				this._shipDate = value;
			}
		}

		private int _status;
		[Required]
		public int Status
		{
			get
			{
				return _status;
			}
			set
			{
				this._status = value;
			}
		}

		private bool _onlineOrderFlag;
		[Required]
		public bool OnlineOrderFlag
		{
			get
			{
				return _onlineOrderFlag;
			}
			set
			{
				this._onlineOrderFlag = value;
			}
		}

		private string _salesOrderNumber;
		[Required]
		public string SalesOrderNumber
		{
			get
			{
				return _salesOrderNumber;
			}
			set
			{
				this._salesOrderNumber = value;
			}
		}

		private string _purchaseOrderNumber;
		public string PurchaseOrderNumber
		{
			get
			{
				return _purchaseOrderNumber.IsEmptyOrZeroOrNull() ? null : _purchaseOrderNumber;
			}
			set
			{
				this._purchaseOrderNumber = value;
			}
		}

		private string _accountNumber;
		public string AccountNumber
		{
			get
			{
				return _accountNumber.IsEmptyOrZeroOrNull() ? null : _accountNumber;
			}
			set
			{
				this._accountNumber = value;
			}
		}

		private int _customerID;
		[Required]
		public int CustomerID
		{
			get
			{
				return _customerID;
			}
			set
			{
				this._customerID = value;
			}
		}

		private Nullable<int> _salesPersonID;
		public Nullable<int> SalesPersonID
		{
			get
			{
				return _salesPersonID.IsEmptyOrZeroOrNull() ? null : _salesPersonID;
			}
			set
			{
				this._salesPersonID = value;
			}
		}

		private Nullable<int> _territoryID;
		public Nullable<int> TerritoryID
		{
			get
			{
				return _territoryID.IsEmptyOrZeroOrNull() ? null : _territoryID;
			}
			set
			{
				this._territoryID = value;
			}
		}

		private int _billToAddressID;
		[Required]
		public int BillToAddressID
		{
			get
			{
				return _billToAddressID;
			}
			set
			{
				this._billToAddressID = value;
			}
		}

		private int _shipToAddressID;
		[Required]
		public int ShipToAddressID
		{
			get
			{
				return _shipToAddressID;
			}
			set
			{
				this._shipToAddressID = value;
			}
		}

		private int _shipMethodID;
		[Required]
		public int ShipMethodID
		{
			get
			{
				return _shipMethodID;
			}
			set
			{
				this._shipMethodID = value;
			}
		}

		private Nullable<int> _creditCardID;
		public Nullable<int> CreditCardID
		{
			get
			{
				return _creditCardID.IsEmptyOrZeroOrNull() ? null : _creditCardID;
			}
			set
			{
				this._creditCardID = value;
			}
		}

		private string _creditCardApprovalCode;
		public string CreditCardApprovalCode
		{
			get
			{
				return _creditCardApprovalCode.IsEmptyOrZeroOrNull() ? null : _creditCardApprovalCode;
			}
			set
			{
				this._creditCardApprovalCode = value;
			}
		}

		private Nullable<int> _currencyRateID;
		public Nullable<int> CurrencyRateID
		{
			get
			{
				return _currencyRateID.IsEmptyOrZeroOrNull() ? null : _currencyRateID;
			}
			set
			{
				this._currencyRateID = value;
			}
		}

		private decimal _subTotal;
		[Required]
		public decimal SubTotal
		{
			get
			{
				return _subTotal;
			}
			set
			{
				this._subTotal = value;
			}
		}

		private decimal _taxAmt;
		[Required]
		public decimal TaxAmt
		{
			get
			{
				return _taxAmt;
			}
			set
			{
				this._taxAmt = value;
			}
		}

		private decimal _freight;
		[Required]
		public decimal Freight
		{
			get
			{
				return _freight;
			}
			set
			{
				this._freight = value;
			}
		}

		private decimal _totalDue;
		[Required]
		public decimal TotalDue
		{
			get
			{
				return _totalDue;
			}
			set
			{
				this._totalDue = value;
			}
		}

		private string _comment;
		public string Comment
		{
			get
			{
				return _comment.IsEmptyOrZeroOrNull() ? null : _comment;
			}
			set
			{
				this._comment = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a3e681d5b64fa708fd865bf49bf5e182</Hash>
</Codenesium>*/