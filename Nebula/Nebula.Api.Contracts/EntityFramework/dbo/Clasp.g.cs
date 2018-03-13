using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    <Hash>870b15bf3431c1c3c754624dc87350b6</Hash>
</Codenesium>*/