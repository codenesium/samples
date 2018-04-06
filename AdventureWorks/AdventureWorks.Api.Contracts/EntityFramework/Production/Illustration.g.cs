using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Illustration", Schema="Production")]
	public partial class EFIllustration
	{
		public EFIllustration()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID {get; set;}
		[Column("Diagram", TypeName="xml(-1)")]
		public string Diagram {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e306ffac4f44df0a479351afafda66f0</Hash>
</Codenesium>*/