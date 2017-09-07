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
		public virtual ChainStatus ChainStatus { get; set; }
		[ForeignKey("teamId")]
		public virtual Team Team { get; set; }
	}
}

/*<Codenesium>
    <Hash>d51af2ffa8be749308ef3b9c3b923cb3</Hash>
</Codenesium>*/