using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class PurchaseOrderHeaderModel
	{
		public PurchaseOrderHeaderModel()
		{}
		public PurchaseOrderHeaderModel(int revisionNumber,
		                                int status,
		                                int employeeID,
		                                int vendorID,
		                                int shipMethodID,
		                                DateTime orderDate,
		                                Nullable<DateTime> shipDate,
		                                decimal subTotal,
		                                decimal taxAmt,
		                                decimal freight,
		                                decimal totalDue,
		                                DateTime modifiedDate)
		{
			this.RevisionNumber = revisionNumber;
			this.Status = status;
			this.EmployeeID = employeeID.ToInt();
			this.VendorID = vendorID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.Freight = freight;
			this.TotalDue = totalDue;
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

		private int _employeeID;
		[Required]
		public int EmployeeID
		{
			get
			{
				return _employeeID;
			}
			set
			{
				this._employeeID = value;
			}
		}

		private int _vendorID;
		[Required]
		public int VendorID
		{
			get
			{
				return _vendorID;
			}
			set
			{
				this._vendorID = value;
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
    <Hash>ccc3cbff23006863d079d9ff6b4941fb</Hash>
</Codenesium>*/