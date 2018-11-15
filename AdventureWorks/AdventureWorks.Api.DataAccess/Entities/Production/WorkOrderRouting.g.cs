using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("WorkOrderRouting", Schema="Production")]
	public partial class WorkOrderRouting : AbstractEntity
	{
		public WorkOrderRouting()
		{
		}

		public virtual void SetProperties(
			decimal? actualCost,
			DateTime? actualEndDate,
			double? actualResourceHr,
			DateTime? actualStartDate,
			short locationID,
			DateTime modifiedDate,
			short operationSequence,
			decimal plannedCost,
			int productID,
			DateTime scheduledEndDate,
			DateTime scheduledStartDate,
			int workOrderID)
		{
			this.ActualCost = actualCost;
			this.ActualEndDate = actualEndDate;
			this.ActualResourceHr = actualResourceHr;
			this.ActualStartDate = actualStartDate;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.OperationSequence = operationSequence;
			this.PlannedCost = plannedCost;
			this.ProductID = productID;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.WorkOrderID = workOrderID;
		}

		[Column("ActualCost")]
		public virtual decimal? ActualCost { get; private set; }

		[Column("ActualEndDate")]
		public virtual DateTime? ActualEndDate { get; private set; }

		[Column("ActualResourceHrs")]
		public virtual double? ActualResourceHr { get; private set; }

		[Column("ActualStartDate")]
		public virtual DateTime? ActualStartDate { get; private set; }

		[Column("LocationID")]
		public virtual short LocationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("OperationSequence")]
		public virtual short OperationSequence { get; private set; }

		[Column("PlannedCost")]
		public virtual decimal PlannedCost { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("ScheduledEndDate")]
		public virtual DateTime ScheduledEndDate { get; private set; }

		[Column("ScheduledStartDate")]
		public virtual DateTime ScheduledStartDate { get; private set; }

		[Key]
		[Column("WorkOrderID")]
		public virtual int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2339e3ecc0e8f5054f49d30e1fa85883</Hash>
</Codenesium>*/