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
		public int workOrderID {get; set;}
		public int productID {get; set;}
		public short operationSequence {get; set;}
		public short locationID {get; set;}
		public DateTime scheduledStartDate {get; set;}
		public DateTime scheduledEndDate {get; set;}
		public Nullable<DateTime> actualStartDate {get; set;}
		public Nullable<DateTime> actualEndDate {get; set;}
		public Nullable<decimal> actualResourceHrs {get; set;}
		public decimal plannedCost {get; set;}
		public Nullable<decimal> actualCost {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>488ec4d72e9faee943c8ec7e49e3da5e</Hash>
</Codenesium>*/