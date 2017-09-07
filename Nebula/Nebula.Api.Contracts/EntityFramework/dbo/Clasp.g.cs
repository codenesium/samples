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
		public virtual Chain Chain { get; set; }
		[ForeignKey("previousChainId")]
		public virtual Chain Chain1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>0487b2039245a59b6482bbad38fda542</Hash>
</Codenesium>*/