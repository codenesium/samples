using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class EFProductModelIllustration
	{
		public EFProductModelIllustration()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID {get; set;}
		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModelRef { get; set; }
		[ForeignKey("IllustrationID")]
		public virtual EFIllustration IllustrationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>0430fa9fdb0d088f9558bda2dafecab5</Hash>
</Codenesium>*/