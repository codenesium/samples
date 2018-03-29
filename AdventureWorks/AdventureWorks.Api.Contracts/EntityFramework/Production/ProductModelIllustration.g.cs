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
		public int ProductModelID {get; set;}
		public int IllustrationID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModelRef { get; set; }
		[ForeignKey("IllustrationID")]
		public virtual EFIllustration IllustrationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>86702f1026bf3ea89c74030bb68aadfb</Hash>
</Codenesium>*/