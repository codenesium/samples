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

		public virtual EFProductModel ProductModel { get; set; }

		public virtual EFIllustration Illustration { get; set; }
	}
}

/*<Codenesium>
    <Hash>b2ffa7cf7fe4bada2bbe8f1cabf380fa</Hash>
</Codenesium>*/