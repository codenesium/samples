using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class EFProductModelIllustration
	{
		public EFProductModelIllustration()
		{}

		public void SetProperties(int productModelID,
		                          int illustrationID,
		                          DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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
    <Hash>3d581aef272cb3fbf90e4e146feb9583</Hash>
</Codenesium>*/