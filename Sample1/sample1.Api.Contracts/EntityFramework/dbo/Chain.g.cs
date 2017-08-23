using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
{
	[Table("Chain", Schema="dbo")]
	public partial class Chain
	{
		public Chain()
		{}

		public int chainStatusId {get; set;}
		public Guid externalId {get; set;}
		[Key]
		public int id {get; set;}
		public string name {get; set;}
		public int teamId {get; set;}

		[ForeignKey("chainStatusId")]
		public virtual ChainStatus ChainStatus { get; set; }
		[ForeignKey("teamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>fd62807cffc768bc2a9399b50fe91728</Hash>
</Codenesium>*/