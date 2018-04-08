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
    <Hash>39f4f90b7024180edbe2ad714e59f8dd</Hash>
</Codenesium>*/