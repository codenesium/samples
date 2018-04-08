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
		public virtual EFProductModel ProductModel { get; set; }
		[ForeignKey("IllustrationID")]
		public virtual EFIllustration Illustration { get; set; }
	}
}

/*<Codenesium>
    <Hash>8855a18b13286e89be3565b991344b50</Hash>
</Codenesium>*/