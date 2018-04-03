using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class WorkOrderRoutingModel
	{
		public WorkOrderRoutingModel()
		{}
		public WorkOrderRoutingModel(int productID,
		                             short operationSequence,
		                             short locationID,
		                             DateTime scheduledStartDate,
		                             DateTime scheduledEndDate,
		                             Nullable<DateTime> actualStartDate,
		                             Nullable<DateTime> actualEndDate,
		                             Nullable<decimal> actualResourceHrs,
		                             decimal plannedCost,
		                             Nullable<decimal> actualCost,
		                             DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.OperationSequence = operationSequence;
			this.LocationID = locationID;
			this.ScheduledStartDate = scheduledStartDate.ToDateTime();
			this.ScheduledEndDate = scheduledEndDate.ToDateTime();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.ActualResourceHrs = actualResourceHrs.ToNullableDecimal();
			this.PlannedCost = plannedCost;
			this.ActualCost = actualCost;
			this.ModifiedDate = modifiedDate.ToDateTime();
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

		private short _operationSequence;
		[Required]
		public short OperationSequence
		{
			get
			{
				return _operationSequence;
			}
			set
			{
				this._operationSequence = value;
			}
		}

		private short _locationID;
		[Required]
		public short LocationID
		{
			get
			{
				return _locationID;
			}
			set
			{
				this._locationID = value;
			}
		}

		private DateTime _scheduledStartDate;
		[Required]
		public DateTime ScheduledStartDate
		{
			get
			{
				return _scheduledStartDate;
			}
			set
			{
				this._scheduledStartDate = value;
			}
		}

		private DateTime _scheduledEndDate;
		[Required]
		public DateTime ScheduledEndDate
		{
			get
			{
				return _scheduledEndDate;
			}
			set
			{
				this._scheduledEndDate = value;
			}
		}

		private Nullable<DateTime> _actualStartDate;
		public Nullable<DateTime> ActualStartDate
		{
			get
			{
				return _actualStartDate.IsEmptyOrZeroOrNull() ? null : _actualStartDate;
			}
			set
			{
				this._actualStartDate = value;
			}
		}

		private Nullable<DateTime> _actualEndDate;
		public Nullable<DateTime> ActualEndDate
		{
			get
			{
				return _actualEndDate.IsEmptyOrZeroOrNull() ? null : _actualEndDate;
			}
			set
			{
				this._actualEndDate = value;
			}
		}

		private Nullable<decimal> _actualResourceHrs;
		public Nullable<decimal> ActualResourceHrs
		{
			get
			{
				return _actualResourceHrs.IsEmptyOrZeroOrNull() ? null : _actualResourceHrs;
			}
			set
			{
				this._actualResourceHrs = value;
			}
		}

		private decimal _plannedCost;
		[Required]
		public decimal PlannedCost
		{
			get
			{
				return _plannedCost;
			}
			set
			{
				this._plannedCost = value;
			}
		}

		private Nullable<decimal> _actualCost;
		public Nullable<decimal> ActualCost
		{
			get
			{
				return _actualCost.IsEmptyOrZeroOrNull() ? null : _actualCost;
			}
			set
			{
				this._actualCost = value;
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
    <Hash>db0cc47339262a11c0ee733bdaea8112</Hash>
</Codenesium>*/