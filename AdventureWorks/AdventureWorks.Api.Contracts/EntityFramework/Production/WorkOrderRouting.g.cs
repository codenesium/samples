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
		public int WorkOrderID {get; set;}
		public int ProductID {get; set;}
		public short OperationSequence {get; set;}
		public short LocationID {get; set;}
		public DateTime ScheduledStartDate {get; set;}
		public DateTime ScheduledEndDate {get; set;}
		public Nullable<DateTime> ActualStartDate {get; set;}
		public Nullable<DateTime> ActualEndDate {get; set;}
		public Nullable<decimal> ActualResourceHrs {get; set;}
		public decimal PlannedCost {get; set;}
		public Nullable<decimal> ActualCost {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("WorkOrderID")]
		public virtual EFWorkOrder WorkOrderRef { get; set; }
		[ForeignKey("LocationID")]
		public virtual EFLocation LocationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>d33973c775dbf1bcacffbddeddd24327</Hash>
</Codenesium>*/