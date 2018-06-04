using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiWorkOrderRequestModel: AbstractApiRequestModel
	{
		public ApiWorkOrderRequestModel() : base()
		{}

		public void SetProperties(
			DateTime dueDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int orderQty,
			int productID,
			short scrappedQty,
			Nullable<short> scrapReasonID,
			DateTime startDate,
			int stockedQty)
		{
			this.DueDate = dueDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty.ToInt();
			this.ProductID = productID.ToInt();
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate.ToDateTime();
			this.StockedQty = stockedQty.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>a578e46fa04a16ac01906b020755b92d</Hash>
</Codenesium>*/