using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPurchaseOrderHeaderModel: AbstractModel
	{
		public ApiPurchaseOrderHeaderModel() : base()
		{}

		public ApiPurchaseOrderHeaderModel(
			int employeeID,
			decimal freight,
			DateTime modifiedDate,
			DateTime orderDate,
			int revisionNumber,
			Nullable<DateTime> shipDate,
			int shipMethodID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			decimal totalDue,
			int vendorID)
		{
			this.EmployeeID = employeeID.ToInt();
			this.Freight = freight.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderDate = orderDate.ToDateTime();
			this.RevisionNumber = revisionNumber.ToInt();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.ShipMethodID = shipMethodID.ToInt();
			this.Status = status.ToInt();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
			this.VendorID = vendorID.ToInt();
		}

		private int employeeID;

		[Required]
		public int EmployeeID
		{
			get
			{
				return this.employeeID;
			}

			set
			{
				this.employeeID = value;
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

		private int vendorID;

		[Required]
		public int VendorID
		{
			get
			{
				return this.vendorID;
			}

			set
			{
				this.vendorID = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2dca4fec03a9c520ffd18314c424f723</Hash>
</Codenesium>*/