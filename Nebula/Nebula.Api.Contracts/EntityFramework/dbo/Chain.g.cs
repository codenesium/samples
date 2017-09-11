using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
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
		public virtual ChainStatus ChainStatusRef { get; set; }
		[ForeignKey("teamId")]
		public virtual Team TeamRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>ae2db4d4e8442d747324a13686f85aad</Hash>
</Codenesium>*/