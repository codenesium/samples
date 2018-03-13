using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    <Hash>d504d0dd7d950b821e119f5205f2ecf0</Hash>
</Codenesium>*/