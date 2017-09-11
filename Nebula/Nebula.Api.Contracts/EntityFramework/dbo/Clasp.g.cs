using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
{
	[Table("Clasp", Schema="dbo")]
	public partial class Clasp
	{
		public Clasp()
		{}

		[Key]
		public int id {get; set;}
		public int nextChainId {get; set;}
		public int previousChainId {get; set;}

		[ForeignKey("nextChainId")]
		public virtual Chain ChainRef { get; set; }
		[ForeignKey("previousChainId")]
		public virtual Chain ChainRef1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>47c031046a399c33c0ad63fb8c991dde</Hash>
</Codenesium>*/