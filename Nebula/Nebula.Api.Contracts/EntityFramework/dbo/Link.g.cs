using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
{
	[Table("Link", Schema="dbo")]
	public partial class Link
	{
		public Link()
		{}

		public Nullable<int> assignedMachineId {get; set;}
		public int chainId {get; set;}
		public Nullable<DateTime> dateCompleted {get; set;}
		public Nullable<DateTime> dateStarted {get; set;}
		public string dynamicParameters {get; set;}
		public Guid externalId {get; set;}
		[Key]
		public int id {get; set;}
		public int linkStatusId {get; set;}
		public string name {get; set;}
		public int order {get; set;}
		public string response {get; set;}
		public string staticParameters {get; set;}

		[ForeignKey("assignedMachineId")]
		public virtual Machine MachineRef { get; set; }
		[ForeignKey("chainId")]
		public virtual Chain ChainRef { get; set; }
		[ForeignKey("linkStatusId")]
		public virtual LinkStatus LinkStatusRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>7df370385e0a78915ad69ebde7389edf</Hash>
</Codenesium>*/