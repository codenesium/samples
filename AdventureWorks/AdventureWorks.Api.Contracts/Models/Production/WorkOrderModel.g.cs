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

		public WorkOrderModel(int productID,
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

		public WorkOrderModel(POCOWorkOrder poco)
		{
			this.OrderQty = poco.OrderQty.ToInt();
			this.StockedQty = poco.StockedQty.ToInt();
			this.ScrappedQty = poco.ScrappedQty;
			this.StartDate = poco.StartDate.ToDateTime();
			this.EndDate = poco.EndDate.ToNullableDateTime();
			this.DueDate = poco.DueDate.ToDateTime();
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.ProductID = poco.ProductID.Value.ToInt();
			this.ScrapReasonID = poco.ScrapReasonID.Value.ToSmallInt();
		}

		private int _productID;
		[Required]
		public int ProductID
		{
			get
			{
				return _productID;
			}
			set
			{
				this._productID = value;
			}
		}

		private int _orderQty;
		[Required]
		public int OrderQty
		{
			get
			{
				return _orderQty;
			}
			set
			{
				this._orderQty = value;
			}
		}

		private int _stockedQty;
		[Required]
		public int StockedQty
		{
			get
			{
				return _stockedQty;
			}
			set
			{
				this._stockedQty = value;
			}
		}

		private short _scrappedQty;
		[Required]
		public short ScrappedQty
		{
			get
			{
				return _scrappedQty;
			}
			set
			{
				this._scrappedQty = value;
			}
		}

		private DateTime _startDate;
		[Required]
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				this._startDate = value;
			}
		}

		private Nullable<DateTime> _endDate;
		public Nullable<DateTime> EndDate
		{
			get
			{
				return _endDate.IsEmptyOrZeroOrNull() ? null : _endDate;
			}
			set
			{
				this._endDate = value;
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

		private Nullable<short> _scrapReasonID;
		public Nullable<short> ScrapReasonID
		{
			get
			{
				return _scrapReasonID.IsEmptyOrZeroOrNull() ? null : _scrapReasonID;
			}
			set
			{
				this._scrapReasonID = value;
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
    <Hash>4d5ef23137728ca731cb18341237e50e</Hash>
</Codenesium>*/