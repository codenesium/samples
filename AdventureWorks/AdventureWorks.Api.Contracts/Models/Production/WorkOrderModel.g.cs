using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class WorkOrderModel
	{
		public WorkOrderModel()
		{}

		public WorkOrderModel(
			int productID,
			int orderQty,
			int stockedQty,
			short scrappedQty,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime dueDate,
			Nullable<short> scrapReasonID,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.OrderQty = orderQty.ToInt();
			this.StockedQty = stockedQty.ToInt();
			this.ScrappedQty = scrappedQty;
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ScrapReasonID = scrapReasonID;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int productID;

		[Required]
		public int ProductID
		{
			get
			{
				return this.productID;
			}

			set
			{
				this.productID = value;
			}
		}

		private int orderQty;

		[Required]
		public int OrderQty
		{
			get
			{
				return this.orderQty;
			}

			set
			{
				this.orderQty = value;
			}
		}

		private int stockedQty;

		[Required]
		public int StockedQty
		{
			get
			{
				return this.stockedQty;
			}

			set
			{
				this.stockedQty = value;
			}
		}

		private short scrappedQty;

		[Required]
		public short ScrappedQty
		{
			get
			{
				return this.scrappedQty;
			}

			set
			{
				this.scrappedQty = value;
			}
		}

		private DateTime startDate;

		[Required]
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}

			set
			{
				this.startDate = value;
			}
		}

		private Nullable<DateTime> endDate;

		public Nullable<DateTime> EndDate
		{
			get
			{
				return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
			}

			set
			{
				this.endDate = value;
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

		private Nullable<short> scrapReasonID;

		public Nullable<short> ScrapReasonID
		{
			get
			{
				return this.scrapReasonID.IsEmptyOrZeroOrNull() ? null : this.scrapReasonID;
			}

			set
			{
				this.scrapReasonID = value;
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
    <Hash>f0312ff9790950a785b2a09ff7907d1f</Hash>
</Codenesium>*/