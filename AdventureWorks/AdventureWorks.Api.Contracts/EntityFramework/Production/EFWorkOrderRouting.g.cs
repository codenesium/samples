using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("WorkOrderRouting", Schema="Production")]
	public partial class EFWorkOrderRouting
	{
		public EFWorkOrderRouting()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("WorkOrderID", TypeName="int")]
		public int WorkOrderID {get; set;}

		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("OperationSequence", TypeName="smallint")]
		public short OperationSequence {get; set;}

		[Column("LocationID", TypeName="smallint")]
		public short LocationID {get; set;}

		[Column("ScheduledStartDate", TypeName="datetime")]
		public DateTime ScheduledStartDate {get; set;}

		[Column("ScheduledEndDate", TypeName="datetime")]
		public DateTime ScheduledEndDate {get; set;}

		[Column("ActualStartDate", TypeName="datetime")]
		public Nullable<DateTime> ActualStartDate {get; set;}

		[Column("ActualEndDate", TypeName="datetime")]
		public Nullable<DateTime> ActualEndDate {get; set;}

		[Column("ActualResourceHrs", TypeName="decimal")]
		public Nullable<decimal> ActualResourceHrs {get; set;}

		[Column("PlannedCost", TypeName="money")]
		public decimal PlannedCost {get; set;}

		[Column("ActualCost", TypeName="money")]
		public Nullable<decimal> ActualCost {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFWorkOrder WorkOrder { get; set; }

		public virtual EFLocation Location { get; set; }
	}
}

/*<Codenesium>
    <Hash>aa128e1eb2ea8d8a185cc35471ff86c3</Hash>
</Codenesium>*/