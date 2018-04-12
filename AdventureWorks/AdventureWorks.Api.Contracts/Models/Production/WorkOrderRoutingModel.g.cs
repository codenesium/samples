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

		public WorkOrderRoutingModel(
			int productID,
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

		private short operationSequence;

		[Required]
		public short OperationSequence
		{
			get
			{
				return this.operationSequence;
			}

			set
			{
				this.operationSequence = value;
			}
		}

		private short locationID;

		[Required]
		public short LocationID
		{
			get
			{
				return this.locationID;
			}

			set
			{
				this.locationID = value;
			}
		}

		private DateTime scheduledStartDate;

		[Required]
		public DateTime ScheduledStartDate
		{
			get
			{
				return this.scheduledStartDate;
			}

			set
			{
				this.scheduledStartDate = value;
			}
		}

		private DateTime scheduledEndDate;

		[Required]
		public DateTime ScheduledEndDate
		{
			get
			{
				return this.scheduledEndDate;
			}

			set
			{
				this.scheduledEndDate = value;
			}
		}

		private Nullable<DateTime> actualStartDate;

		public Nullable<DateTime> ActualStartDate
		{
			get
			{
				return this.actualStartDate.IsEmptyOrZeroOrNull() ? null : this.actualStartDate;
			}

			set
			{
				this.actualStartDate = value;
			}
		}

		private Nullable<DateTime> actualEndDate;

		public Nullable<DateTime> ActualEndDate
		{
			get
			{
				return this.actualEndDate.IsEmptyOrZeroOrNull() ? null : this.actualEndDate;
			}

			set
			{
				this.actualEndDate = value;
			}
		}

		private Nullable<decimal> actualResourceHrs;

		public Nullable<decimal> ActualResourceHrs
		{
			get
			{
				return this.actualResourceHrs.IsEmptyOrZeroOrNull() ? null : this.actualResourceHrs;
			}

			set
			{
				this.actualResourceHrs = value;
			}
		}

		private decimal plannedCost;

		[Required]
		public decimal PlannedCost
		{
			get
			{
				return this.plannedCost;
			}

			set
			{
				this.plannedCost = value;
			}
		}

		private Nullable<decimal> actualCost;

		public Nullable<decimal> ActualCost
		{
			get
			{
				return this.actualCost.IsEmptyOrZeroOrNull() ? null : this.actualCost;
			}

			set
			{
				this.actualCost = value;
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
    <Hash>6ad2efda52ebc8296708c91a5936c770</Hash>
</Codenesium>*/