using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
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
		public virtual Chain Chain { get; set; }
		[ForeignKey("previousChainId")]
		public virtual Chain Chain1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>9030f6711755bdcf3b60a3236a445440</Hash>
</Codenesium>*/