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

		public PurchaseOrderHeaderModel(
			int revisionNumber,
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
			this.RevisionNumber = revisionNumber.ToInt();
			this.Status = status.ToInt();
			this.EmployeeID = employeeID.ToInt();
			this.VendorID = vendorID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.Freight = freight.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
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
    <Hash>76169092e0305d797a1d3f089916ebe4</Hash>
</Codenesium>*/