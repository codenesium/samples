using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
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
		public virtual Machine Machine { get; set; }
		[ForeignKey("chainId")]
		public virtual Chain Chain { get; set; }
		[ForeignKey("linkStatusId")]
		public virtual LinkStatus LinkStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>393f2fa2f96db786cc8579834f14e3af</Hash>
</Codenesium>*/