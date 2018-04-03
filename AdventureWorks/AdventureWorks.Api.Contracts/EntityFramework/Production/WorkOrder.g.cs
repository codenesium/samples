using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("WorkOrder", Schema="Production")]
	public partial class EFWorkOrder
	{
		public EFWorkOrder()
		{}

		[Key]
		public int workOrderID {get; set;}
		public int productID {get; set;}
		public int orderQty {get; set;}
		public int stockedQty {get; set;}
		public short scrappedQty {get; set;}
		public DateTime startDate {get; set;}
		public Nullable<DateTime> endDate {get; set;}
		public DateTime dueDate {get; set;}
		public Nullable<short> scrapReasonID {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>1d1b87ae88e6e66bac87c468fa204ab5</Hash>
</Codenesium>*/